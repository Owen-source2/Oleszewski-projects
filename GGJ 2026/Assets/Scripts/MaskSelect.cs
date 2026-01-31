using UnityEngine;
using TMPro;

public class MaskSelect : MonoBehaviour
{
    public int maskSelected=0;
    public UI_Manager uiManager;
    public PlayerStateMachine playerStateMachine;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        uiManager.UpdateCurrentMask(maskSelected);
    }
    public void SwitchMask(int switchMaskTo)
    {
        if (switchMaskTo == 1)
        {
            playerStateMachine.playerState=PlayerStateMachine.PlayerState.DashMask;
        }  
        else if (switchMaskTo == 2)
        {
            playerStateMachine.playerState=PlayerStateMachine.PlayerState.StompMask;
        }
        else if (switchMaskTo == 3)
        {
            playerStateMachine.playerState=PlayerStateMachine.PlayerState.WarpMask;
        }
        maskSelected=switchMaskTo;
    }
}
