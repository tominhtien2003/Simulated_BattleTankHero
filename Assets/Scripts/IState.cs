using UnityEngine;

public interface IState
{
    void Enter();
    void Excute();
    void Exit();
    string GetTypeState();
}
