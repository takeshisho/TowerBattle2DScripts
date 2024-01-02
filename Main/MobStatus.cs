using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MobAttack))]
[RequireComponent(typeof(MobMove))]
public class MobStatus : MobManager
{
    const int RIGHT = 1;
    const int LEFT = -1;
    private int forwardDirection = LEFT;
    private bool isMovable = true;
    private int enemyCount = 0;
    // private bool isAttackable = false;
    MobMove mobMove;
    MobAttack mobAttack;

    private void Start()
    {
        if (IsEnemy) forwardDirection = RIGHT;
        mobMove =  GetComponent<MobMove>();
        mobAttack = GetComponent<MobAttack>();
    }

    private void Update() 
    {
        if(isMovable) mobMove.Move(Speed, forwardDirection);
        
    }


    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            enemyCount++;
            isMovable = false;
            mobAttack.AttackStart(Damage, AttackCooltime, other.gameObject.GetComponent<HitPoint>());
        }
    }

    // 現状はすべてのキャラが範囲攻撃になっている。
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            // TODO: 一体敵を倒してもまだ敵がいる場合は処理をしない。
            enemyCount--;
            if(enemyCount > 0) return;
            isMovable = true;
            mobAttack.AttackExit();
        }
    }
}
