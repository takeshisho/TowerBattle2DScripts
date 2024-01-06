using UnityEngine;

[RequireComponent(typeof(MobManager))]
public class MobHitPoint : HitPoint
{
    [SerializeField] GameObject DieEffect;

    protected override void Start() {
        Hp = GetComponent<MobManager>().MaxHp; 
    }

    protected override void OnDie()
    {
        if(DieEffect != null) 
        {
            Instantiate(DieEffect, transform.position, Quaternion.Euler(-90, 0, 0));
        }

        base.OnDie();

        if(gameObject.tag == "enemy")
        {
            Score.Instance.AddDefeatedEnemyNum();
        }
        // TODO: コスト上昇など
    }
}
