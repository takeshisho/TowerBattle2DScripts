using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHitPoint : HitPoint
{

    protected override void Start() {
        // Hp = GetComponent<TowerManager>().MaxHp;
    }

    protected override void OnDie()
    {
        base.OnDie();
        // アニメーション生成など
    }
}
