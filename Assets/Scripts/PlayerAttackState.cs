using UnityEngine;
public class PlayerAttackState : IState
{
    private PlayerController playerController;
    public PlayerAttackState(PlayerController playerController)
    {
        this.playerController = playerController;
    }
    public void Enter()
    {
        playerController.HandleIdleStatePlayer();
    }

    public void Excute()
    {
        playerController.HandleAttack();
    }

    public void Exit()
    {

    }
    public string GetTypeState()
    {
        return "Attack";
    }
}
