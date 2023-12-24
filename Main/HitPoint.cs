using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public int Hp;

    private void Start() {
        Hp = GetComponent<MobManager>().MaxHp;
    }

    public void Damage(int damage)
    {
        Hp -= damage;
        if (Hp <= 0) OnDie();
    }

    private void OnDie()
    {
        Destroy(gameObject);
    }

}
