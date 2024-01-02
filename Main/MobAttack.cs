using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HitPoint))]
public class MobAttack : MonoBehaviour
{
    Animator animator;

    private void Start() {
        animator = GetComponent<Animator>();
    }

    public void AttackStart(int damage, float attackCooltime, HitPoint hitpoint) 
    {
        animator.SetBool("isAttack", true);
        StartCoroutine(AttackAction(hitpoint, damage, attackCooltime));
    }

    public void AttackExit() 
    {
        animator.SetBool("isAttack", false);
    }

    IEnumerator AttackAction(HitPoint targetHitPoint, int damage, float attackCooltime) {

        while(targetHitPoint.Hp > 0) 
        {
            yield return new WaitForSeconds(attackCooltime);

            /* 複数いる場合にwaitしている場合に敵が死ぬとエラーになるため。
               これをしてもEnter時のみしか攻撃処理が始まらないので、上手くはいかない。
               TODO: 複数体いる場合の攻撃処理を考える。*/
            // try catchのおかけでエラーにならずに済むかも！！作成後に何度もテストして確認！

            try {
                targetHitPoint.Damage(damage);
            } 
            catch (Exception) {
                Debug.Log("<color=red>エラー: 攻撃対象がいなくなりました</color>");
                break;
            }            
        }
    }
}
