using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MobAttack : MonoBehaviour
{
    Animator animator;
    [SerializeField] AudioSource AttackSound;

    private void Start() 
    {
        animator = GetComponent<Animator>();
    }

    public void AttackStart(HitPoint hitpoint, int damage, float attackCooltime) 
    {
        StartCoroutine(AttackAction(hitpoint, damage, attackCooltime));
    }

    public void AttackExit() 
    {
        animator.SetBool("isAttack", false);
    }

    IEnumerator AttackAction(HitPoint targetHitPoint, int damage, float attackCooltime) 
    {

        while(targetHitPoint.Hp > 0) 
        {
            yield return new WaitForSeconds(attackCooltime);
            if(AttackSound != null) AttackSound.Play();
            animator.SetBool("isAttack", true);

            try 
            {
                targetHitPoint.Damage(damage);
            } 
            catch (Exception) 
            {
                animator.SetBool("isAttack", false);
                break;
            }            
        }
        animator.SetBool("isAttack", false);
    }
}
