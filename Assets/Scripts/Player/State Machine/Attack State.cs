using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : iState
{
    float timer = 0;
    public void OnEnter(Enemy enemy)
    {
        if (enemy.Target != null)
        {
            enemy.StopMoving();
            enemy.Attack();
        }   
    }

    public void OnExecute(Enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer >= 2f)
        {
            enemy.ChangeState(new PatrolState());
        }
    }

    public void OnExit(Enemy enemy)
    {

    }
}
