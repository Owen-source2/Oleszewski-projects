using UnityEngine;

public class PatrolAndHunt : MonoBehaviour
{
    [SerializeField]
    float speed=1.0f;
    enum patrolState
    {
        Patrolling,
        Hunting,
    }
    [SerializeField]
    GameObject[] route;
    GameObject target;
    int routeIndex=0;
    patrolState GetPatrolState=patrolState.Patrolling;
    public GameObject detector;

    void Update()
    {
        
        switch(GetPatrolState)
        {
            case patrolState.Patrolling:
                patrol();
                break;
            case patrolState.Hunting:
                hunt();
                break;
        }
    }
    void patrol()
    {
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
        if(detector.GetComponent<Detect>().trackingPlayer)
        {
            GetPatrolState=patrolState.Hunting;
        }
    }
    void hunt()
    {
        target=detector.GetComponent<Detect>().foundPlayer;
        MoveTo(target);
    }
    void MoveTo(GameObject t)
    {
        transform.position=Vector3.MoveTowards(transform.position,t.transform.position,speed*Time.deltaTime);
        transform.LookAt(t.transform, Vector3.up);
    }
}
