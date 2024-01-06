using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] MobData mobData;
    // プロパティ
    public string MobName { get { return mobData.name; } }
    public int MaxHp { get { return mobData.maxHp; } }
    public int Damage { get { return mobData.damage; } }
    public float Speed { get { return mobData.speed; } }
    public int Cost { get { return mobData.cost; } }
    public float Cooltime { get { return mobData.cooltime; } }
    public float AttackCooltime { get { return mobData.AttackCooltime; } }
    public bool IsEnemy { get { return mobData.isEnemy; } }
}
