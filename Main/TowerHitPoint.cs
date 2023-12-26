using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerHitPoint : HitPoint
{
    [SerializeField] TextMeshProUGUI HpText;
    private int MaxHp;

    protected override void Start() {
        // Hp = GetComponent<TowerManager>().MaxHp;
        Hp = 10;
        MaxHp = Hp;
        HpText.text = Hp.ToString() + "/" + MaxHp.ToString();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        HpText.text = Hp.ToString() + "/" + MaxHp.ToString();
    }

    protected override void OnDie()
    {
        base.OnDie();
        // アニメーション生成など
    }
}
