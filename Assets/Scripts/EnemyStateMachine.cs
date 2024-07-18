using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public IEnemyState currentEnemyState;
    public void ChangeState(IEnemyState enemyState)
    {
        if (currentEnemyState != null && enemyState.GetTypeState() == currentEnemyState.GetTypeState())
        {
            return;
        }
        if (currentEnemyState != null)
        {
            currentEnemyState.Exit();
        }
        currentEnemyState = enemyState;

        if (currentEnemyState != null)
        {
            currentEnemyState.Enter();
        }
    }
    private void Update()
    {
        if (currentEnemyState != null)
        {
            currentEnemyState.Excute();
        }
    }
}
