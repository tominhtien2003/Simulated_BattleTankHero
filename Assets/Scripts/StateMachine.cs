using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public IState currentPlayerState;
    public void ChangeState(IState state)
    {
        if (currentPlayerState != null && state.GetTypeState() == currentPlayerState.GetTypeState())
        {
            return;
        }
        if (currentPlayerState != null)
        {
            currentPlayerState.Exit();
        }
        currentPlayerState = state;

        if (currentPlayerState != null)
        {
            currentPlayerState.Enter();
        }
    }
    private void Update()
    {
        if (currentPlayerState != null)
        {
            currentPlayerState.Excute();
        }
    }
}
