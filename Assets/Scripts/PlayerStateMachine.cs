using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public IPlayerState currentPlayerState;
    public void ChangeState(IPlayerState playerState)
    {
        if (currentPlayerState != null && playerState.GetTypeState() == currentPlayerState.GetTypeState())
        {
            return;
        }
        if (currentPlayerState != null)
        {
            currentPlayerState.Exit();
        }
        currentPlayerState = playerState;

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
