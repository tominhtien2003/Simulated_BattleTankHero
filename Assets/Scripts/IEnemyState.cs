using UnityEngine;

public interface IEnemyState 
{
    void Enter();
    void Excute();
    void Exit();
    string GetTypeState();
}
