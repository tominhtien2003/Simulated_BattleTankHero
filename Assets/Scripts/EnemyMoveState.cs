public class EnemyMoveState : IState
{
    private EnemyController enemyController;
    public EnemyMoveState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
    public void Enter()
    {
    }

    public void Excute()
    {
        enemyController.HandleMovementEnemy();
    }

    public void Exit()
    {
    }

    public string GetTypeState()
    {
        return "Move";
    }
}
