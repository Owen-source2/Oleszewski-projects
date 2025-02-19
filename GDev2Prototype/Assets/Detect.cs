using UnityEngine;

public class Detect : MonoBehaviour
{
    public enum detectionState
    {
        Player,
        NoPlayer
    }
    bool runTimer=false;
    float startTime;
    public float intrestTime = 10.0f;
    public GameObject foundPlayer;
    public detectionState detected = detectionState.NoPlayer;
    public bool trackingPlayer = false;
    void OnTriggerEnter(Collider collider)
    {
        foundPlayer=collider.transform.gameObject;
        if (foundPlayer.GetComponent<KinematicMomentum>()!=null)
        {
            detected=detectionState.Player;
            trackingPlayer=true;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<KinematicMomentum>()!=null)
        {
            runTimer=true;
        }
    }
    void Update()
    {
        if(!runTimer){
            startTime=Time.realtimeSinceStartup;
        }
        else
        {
            if(Time.realtimeSinceStartup<=startTime+intrestTime)
            {
                detected=detectionState.Player;
                trackingPlayer=true;
            }
            else
            {
                detected=detectionState.NoPlayer;
                trackingPlayer=false;
            }
        }
    }
}
