using UnityEngine;

public class StealthEnemy : MonoBehaviour
{
    Animator anim;
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
    void Start()
    {
        anim=GetComponent<Animator>();
    }
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
        anim.SetBool("Following",false);
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
        anim.SetBool("Following",true);
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
            playerStateManager player = hit.transform.gameObject.GetComponent<playerStateManager>();
            if(player!=null)
            {
                if(player.currentState!=player.sneakState)
                {
                    print(hit.transform.gameObject.name);
                    return hit.transform.gameObject;
                }
            }
        }
        return null;
    }
}
