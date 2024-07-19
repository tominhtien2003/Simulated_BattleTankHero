public class EnemyIdleState : IState
{
    private EnemyController enemyController;
    public EnemyIdleState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }

    public void Enter()
    {
    }

    public void Excute()
    {
        enemyController.HandleIdleEnemy();
    }

    public void Exit()
    {
    }

    public string GetTypeState()
    {
        return "Idle";
    }
}
