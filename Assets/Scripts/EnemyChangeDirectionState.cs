
using UnityEngine;

public class EnemyChangeDirectionState : IState
{
    private EnemyController enemyController;
    public EnemyChangeDirectionState(EnemyController enemyController)
    {
        this.enemyController = enemyController;
    }
    public void Enter()
    {
        //Debug.Log("Enter Change Direction");
    }

    public void Excute()
    {
        enemyController.HandleChangeDirectionEnemy();
    }

    public void Exit()
    {
    }

    public string GetTypeState()
    {
        return "ChangeDirection";
    }
}
