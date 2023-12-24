using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MobStatus : MobManager
{
    const int RIGHT = 1;
    const int LEFT = -1;
    private int forwardDirection = LEFT;
    private bool isMoveable = true;
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
        if(isMoveable) mobMove.Move(Speed, forwardDirection);
        
    }

    // TODO: 動画と違い、stayをつけることで複数敵がいた場合1体倒したら前に進むということが
    // ないようにしたつもり。攻撃判定、死亡判定作成後に確認する。
    // また他にいい方法がないかも考える。stayは毎フレーム呼び出してしまうから。

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            isMoveable = false;
            mobAttack.AttackStart(Damage, Cooltime, other.gameObject.GetComponent<HitPoint>());
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            isMoveable = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" && this.gameObject.tag == "Player"
            || other.gameObject.tag == "Player" && this.gameObject.tag == "Enemy") 
        {
            isMoveable = true;
            mobAttack.AttackExit();
        }
    }
}
