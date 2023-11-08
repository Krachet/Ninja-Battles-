using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Animator anim;

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
    }



    public virtual void OnDespawn()
    {
        
    }

    protected virtual void OnDeath()
    {
        OnDespawn();
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
        }
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
}
