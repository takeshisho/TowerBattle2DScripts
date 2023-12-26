using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public int Hp;

    protected virtual void Start() {
        // towerとmobでHpの取得方法が違うので、それぞれのクラスで実装する
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0) OnDie();
    }

    protected virtual void OnDie()
    {
        Destroy(gameObject);
    }

}
