
using UnityEngine;

public class PlayerChangeDirectionState : IPlayerState
{
    private PlayerController playerController;
    public PlayerChangeDirectionState(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public void Enter()
    {
        
    }

    public void Excute()
    {
        playerController.HandleChangeDirection();
    }

    public void Exit()
    {
        
    }
    public string GetTypeState()
    {
        return "ChangeDirection";
    }
}
