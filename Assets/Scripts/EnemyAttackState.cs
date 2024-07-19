public class EnemyAttackState : IState
{
    private EnemyController enemyController;
    public EnemyAttackState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
    public void Enter()
    {
    }

    public void Excute()
    {
        enemyController.HandleAttackEnemy();
    }

    public void Exit()
    {
    }

    public string GetTypeState()
    {
        return "Attack";
    }
}
