using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float range;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;

    private iState currentState;

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }
    public override void OnInit() 
    {
        base.OnInit();

        ChangeState(new Idle());
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }

    public void ChangeState(iState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }

        currentState = newState;

        if (currentState != null)
        {
            currentState.OnEnter(this);
        }
    }

    public void Moving()
    {
        Changeanim("Run");
        rb.velocity = transform.right * moveSpeed;
    }

    public void StopMoving()
    {
        Changeanim("Idle");
        rb.velocity = Vector2.zero;
    }

    public void Attack()
    {

    }

    public bool InRange()
    {
        return false;
    }


}
