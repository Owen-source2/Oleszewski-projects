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
        WarpMask,
        Burning
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
                    player.StartDash();
                }
                break;
            case PlayerState.StompMask:
                if (Input.GetKeyDown(maskKey))
                {
                    player.StartStomp();
                }
                break;
            case PlayerState.WarpMask:
                if (Input.GetKeyDown(maskKey))
                {
                    player.StartWarp();
                }
                break;
            case PlayerState.Burning:
                player.LavaBounce();
                break;
        }
    }
}
