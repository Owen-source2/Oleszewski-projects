using UnityEngine;

public class StealthEnemy : MonoBehaviour
{

    [SerializeField]
    float speed=1.0f;
    //public float patrolDistance = 10f;
    public enum state
    {
        Pacing,
        Following,
    }
    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex=0;
    public state currentState = state.Pacing;
    void Update()
    {
        switch(currentState)
        {
            case state.Pacing:
                pacing();
                break;
            case state.Following:
                following();
                break;
        }
    }
    void pacing(){
        print("Pacing");
        //Follow target
        target=route[routeIndex];
        MoveTo(target);
        if(Vector3.Distance(transform.position,target.transform.position)<0.1)
        {
            routeIndex++;
            if(routeIndex>=route.Length)
            {
                routeIndex=0;
            }
        }
        GameObject obstacle = CheckForward();
        if (obstacle!=null)
        {
            target=obstacle;
            speed=speed*2;
            currentState=state.Following;
        }
    }
    void following()
    {
        print("Following");
        MoveTo(target);

        GameObject obstacle=CheckForward();
        if(obstacle==null)
        {
            speed=speed/2;
            currentState=state.Pacing;
        }
    }



    void MoveTo(GameObject t)
    {
        transform.position=Vector3.MoveTowards(transform.position,t.transform.position,speed*Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }
    GameObject CheckForward()
    {
        RaycastHit hit;
        //Debug.DrawRay(transform.position,transform.forward*10,Color green);
        if(Physics.Raycast(transform.position,transform.forward,out hit,10))
        {
            FPControl player = hit.transform.gameObject.GetComponent<FPControl>();
            if(player!=null)
            {
                print(hit.transform.gameObject.name);
                return hit.transform.gameObject;
            }
        }
        return null;
    }
}
