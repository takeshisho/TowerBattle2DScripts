using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] MobData mobData;
    // プロパティ
    public string MobName { get { return mobData.name; } }
    public int MaxHp { get { return mobData.maxHp; } }
    public int Damage { get { return mobData.damage; } }
    public float MovingSpeed { get { return mobData.movingSpeed; } }
    public int Cost { get { return mobData.cost; } }
    public float SpawnCooltime { get { return mobData.spawnCooltime; } }
    public float AttackCooltime { get { return mobData.AttackCooltime; } }
    public bool IsEnemy { get { return mobData.isEnemy; } }
}
