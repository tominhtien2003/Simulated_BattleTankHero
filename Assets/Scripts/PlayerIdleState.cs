using UnityEngine;

public class PlayerIdleState : IPlayerState
{
    private PlayerController playerController;
    public PlayerIdleState(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void Enter()
    {
        Debug.Log("Enter Idle");
    }

    public void Excute()
    {
        Debug.Log("Excute Idle");
    }

    public void Exit()
    {
        Debug.Log("Exit Idle");
    }

    public string GetTypeState()
    {
        return "Idle";
    }
}
