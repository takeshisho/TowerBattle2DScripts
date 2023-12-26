using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MobManager))]
public class MobHitPoint : HitPoint
{
    protected override void Start() {
        Hp = GetComponent<MobManager>().MaxHp;
    }

    protected override void OnDie()
    {
        base.OnDie();
        // TODO: アニメーション再生,スコア上昇、コスト上昇など
    }
}
