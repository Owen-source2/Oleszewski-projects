using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerMove player;
    public KeyCode maskKey;
    public enum PlayerState
    {
        NoMask,
        DashMask,
        StompMask,
        WarpMask
    }
    public PlayerState playerState = PlayerState.NoMask;
    // Update is called once per frame
    void Update()
    {
        switch (playerState)
        {
            case PlayerState.NoMask:
                break;
            case PlayerState.DashMask:
                if (Input.GetKeyDown(maskKey))
                {
                    player.Dash();
                }
                break;
            case PlayerState.StompMask:
                if (Input.GetKeyDown(maskKey))
                {
                    player.Stomp();
                }
                break;
            case PlayerState.WarpMask:
                if (Input.GetKeyDown(maskKey))
                {
                    player.Warp();
                }
                break;
        }
    }
}
