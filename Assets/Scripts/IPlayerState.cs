using UnityEngine;

public interface IPlayerState
{
    void Enter();
    void Excute();
    void Exit();
    string GetTypeState();
}
