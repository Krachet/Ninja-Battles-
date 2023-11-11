using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] protected Healthbar healthbar;

    private iState currentState;
    private float hp;
    private string currentAnim;

    public bool IsDead => hp <= 0;

    private void Start()
    {
        OnInit();
    }

    public virtual void OnInit()
    {
        hp = 100;
        //healthbar.OnInit(100, transform);
    }

    private void Update()
    {
        if (currentState != null)
        {
            currentState.OnExecute(this);
        }
    }

    public virtual void OnDespawn()
    {

    }

    protected virtual void OnDeath()
    {
        Changeanim("Die");
        Invoke(nameof(OnDespawn), 1f);
    }

    public void OnHit(float damage)
    {
        if (!IsDead)
        {
            hp -= damage;
            if (IsDead)
            {
                OnDeath();
            }
            healthbar.SetHp(hp);
        }
        healthbar.SetHp(hp);
    }

    public void Heal(float amount)
    {
        hp += amount;
        healthbar.SetHp(hp);
    }

    protected void Changeanim(string animName)
    {
        if (currentAnim != animName)
        {
            anim.ResetTrigger(animName);
            currentAnim = animName;
            anim.SetTrigger(currentAnim);
        }
    }

    protected void ChangeState(iState newState)
    {
        if (currentState != null)
        {
            currentState.OnExit(this);
        }
        currentState = newState;
        currentState.OnEnter(this);
    }
}
