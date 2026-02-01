using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public PlayerMove player;
    public KeyCode maskKey;
    public GameObject dashMask;
    public GameObject stompMask;
    public GameObject warpMask;
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
                dashMask.SetActive(false);
                stompMask.SetActive(false);
                warpMask.SetActive(false);
                break;
            case PlayerState.DashMask:
                dashMask.SetActive(true);
                stompMask.SetActive(false);
                warpMask.SetActive(false);
                if (Input.GetKeyDown(maskKey))
                {
                    player.StartDash();
                }
                break;
            case PlayerState.StompMask:
                dashMask.SetActive(false);
                stompMask.SetActive(true);
                warpMask.SetActive(false);
                if (Input.GetKeyDown(maskKey))
                {
                    player.StartStomp();
                }
                break;
            case PlayerState.WarpMask:
                dashMask.SetActive(false);
                stompMask.SetActive(false);
                warpMask.SetActive(true);
                if (Input.GetKeyDown(maskKey))
                {
                    player.StartWarp();
                }
                break;
            case PlayerState.Burning:
                dashMask.SetActive(false);
                stompMask.SetActive(false);
                warpMask.SetActive(false);
                player.LavaBounce();
                break;
        }
    }
}
