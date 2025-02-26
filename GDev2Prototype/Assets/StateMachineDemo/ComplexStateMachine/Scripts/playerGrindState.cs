using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;


public class playerGrindState:PlayerBaseState
{
    public bool canGrind=true;
    float grindSpeed;
    float heightOffset=1.5f;
    float timeForFullSpline;
    float elapsedTime;
    float lerpSpeed = 1f;
    railScript currentRailScript;
    
    public override void EnterState(playerStateManager player)
    {
        grindSpeed=player.grindSpeed;
        currentRailScript=player.currentRailScript;
        //player.FindRail(player.grindState);
        
        
        Debug.Log("Grinding");
    }
    public override void UpdateState(playerStateManager player)
    {
        CalculateAndSetRailPosition(player); 
        MovePlayerAlongRail(player);
    } 
    //All code below this point is from a YouTube tutorial, https://www.youtube.com/watch?v=Kxempc3fKz4
    public void MovePlayerAlongRail(playerStateManager player)
    {
        if (currentRailScript != null && player.onRail) //This is just some additional error checking.
        {
            //Debug.Log(new Vector2(elapsedTime,timeForFullSpline));
            //Calculate a 0 to 1 normalised time value which is the progress along the rail.
            //Elapsed time divided by the full time needed to traverse the spline will give you that value.
            float progress = elapsedTime / timeForFullSpline;
//            Debug.Log(progress);
            //If progress is less than 0, the player's position is before the start of the rail.
            //If greater than 1, their position is after the end of the rail.
            //In either case, the player has finished their grind.
            if (progress <= 0 || progress >= 1)
            {
                
                ThrowOffRail(player);
                player.SwitchState(player.jumpOff);
                return;
            }
            //The rest of this code will not execute if the player is thrown off.

            //Next Time Normalised is the player's progress value for the next update.
            //This is used for calculating the player's rotation.
            //Depending on the direction of the player on the spline, it will either add or subtract time from the
            //current elapsed time.
            float nextTimeNormalised;
            if (currentRailScript.normalDir)
                nextTimeNormalised = (elapsedTime + Time.deltaTime) / timeForFullSpline;
            else
                nextTimeNormalised = (elapsedTime - Time.deltaTime) / timeForFullSpline;

            //Calculating the local positions of the player's current position and next position
            //using current progress and the progress for the next update.
            float3 pos, tangent, up;
            float3 nextPosfloat, nextTan, nextUp;
            SplineUtility.Evaluate(currentRailScript.railSpline.Spline, progress, out pos, out tangent, out up);
            SplineUtility.Evaluate(currentRailScript.railSpline.Spline, nextTimeNormalised, out nextPosfloat, out nextTan, out nextUp);

            //Converting the local positions into world positions.
            Vector3 worldPos = currentRailScript.LocalToWorldConversion(pos);
            Vector3 nextPos = currentRailScript.LocalToWorldConversion(nextPosfloat);

            //Setting the player's position and adding a height offset so that they're sitting on top of the rail
            //instead of being in the middle of it.
            player.transform.position = worldPos + (player.transform.up * heightOffset);
            //Lerping the player's current rotation to the direction of where they are to where they're going.
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.LookRotation(nextPos - worldPos), lerpSpeed * Time.deltaTime);
            //Lerping the player's up direction to match that of the rail, in relation to the player's current rotation.
            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, Quaternion.FromToRotation(player.transform.up, up) * player.transform.rotation, lerpSpeed * Time.deltaTime);
            //Finally incrementing or decrementing elapsed time for the next update based on direction.
            if (currentRailScript.normalDir)
            {
                elapsedTime += Time.deltaTime;
            }
            else
            {
                elapsedTime -= Time.deltaTime;
            }
        }
    }
    public void CalculateAndSetRailPosition(playerStateManager player)
    {
        //Debug.Log();
        //Figure out the amount of time it would take for the player to cover the rail.
        timeForFullSpline = currentRailScript.totalSplineLength / grindSpeed;
        Debug.Log(new Vector2(currentRailScript.totalSplineLength,grindSpeed));
        //This is going to be the world position of where the player is going to start on the rail.
        Vector3 splinePoint;

        //The 0 to 1 value of the player's position on the spline. We also get the world position of where that
        //point is.
        float normalisedTime = currentRailScript.CalculateTargetRailPoint(player.transform.position, out splinePoint);
        
        elapsedTime = timeForFullSpline * normalisedTime;
        
        //Multiply the full time for the spline by the normalised time to get elapsed time. This will be used in
        //the movement code.

        //Spline evaluate takes the 0 to 1 normalised time above, 
        //and uses it to give you a local position, a tangent (forward), and up
        float3 pos, forward, up;
        SplineUtility.Evaluate(currentRailScript.railSpline.Spline, normalisedTime, out pos, out forward, out up);
        //Calculate the direction the player is going down the rail
        currentRailScript.CalculateDirection(forward, player.transform.forward);
        //Set player's initial position on the rail before starting the movement code.
        player.transform.position = splinePoint + (player.transform.up * heightOffset);
    }
    public void ThrowOffRail(playerStateManager player)
    {
        Debug.Log("off rail");
        //Set onRail to false, clear the rail script, and push the player off the rail.
        //It's a little sudden, there might be a better way of doing using coroutines and looping, but this will work.
        player.onRail = false;
        currentRailScript = null;
        player.transform.position += player.transform.forward * 1;
    }
}
