using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private PlayerMovement mov;
    private PlayerAnimator anim;

    public bool isAttacking;
    public float attackCooldown, maxAttackCooldown, attackTime, maxAttackTime;

    public GameObject attackEffect, attackEffect2;

    private void Start()
    {
        mov = GetComponent<PlayerMovement>();
        anim = GetComponent<PlayerAnimator>();
    }

    public void Update()
    {
        if(attackCooldown > 0 && !anim.justAttacked)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (attackTime > 0)
        {
            attackTime -= Time.deltaTime;
        }
        if (attackTime <= 0)
        {
            attackTime = 0;
            attackEffect.SetActive(false);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public void Attack()
    {
        if (CanAttack()) 
        { 
            anim.justAttacked = true; 
            attackCooldown = maxAttackCooldown;
            attackEffect.SetActive(true);
            attackEffect.GetComponent<Animator>().SetTrigger("Enable");

            attackEffect2.SetActive(true);
            attackEffect2.GetComponent<Animator>().SetTrigger("Enable");

            attackTime = maxAttackTime;
        }
    }

    public bool CanAttack()
    {
        return !isAttacking && attackCooldown <=0;
    }

}
