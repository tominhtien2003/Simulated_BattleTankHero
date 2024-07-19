using UnityEngine;

public class PlayerMoveState : IState
{
    private PlayerController playerController;
    public PlayerMoveState(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public void Enter()
    {
        
    }

    public void Excute()
    {
        playerController.HandleMovementPlayer();
    }

    public void Exit()
    {
        
    }
    public string GetTypeState()
    {
        return "Move";
    }
}
