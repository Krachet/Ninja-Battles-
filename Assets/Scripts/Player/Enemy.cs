using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [SerializeField] private float range;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject attackArea;

    //private iState currentState;

    private bool isRight = true;

    private Character target;
    public Character Target => target;

    private void Update()
    {
        
    }

    public override void OnInit() 
    {
        base.OnInit();

        //ChangeState(new Idle());
        //InActiveAttack();
    }

    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(healthbar.gameObject);
        Destroy(gameObject);
    }

    protected override void OnDeath()
    {
        base.OnDeath();
    }
}
