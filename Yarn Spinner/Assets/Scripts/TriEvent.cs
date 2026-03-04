using UnityEngine;
using Yarn.Unity;

public class TriEvent : MonoBehaviour
{
    private ConstantForce2D constF;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        constF=GetComponent<ConstantForce2D>();
    }

    YarnCommand("GoTri");
    public void GoTri()
    {
        constF.enabled=true;
    }
}
