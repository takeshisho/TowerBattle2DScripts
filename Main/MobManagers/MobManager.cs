using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobManager : MonoBehaviour
{
    [SerializeField] MobData mobData;
    // プロパティ
    public string MobName { get { return mobData.name; } }
    public float Hp { get { return mobData.hp; } }
    public float Strength { get { return mobData.strength; } }
    public float Speed { get { return mobData.speed; } }
    public int Cost { get { return mobData.cost; } }
    public int Cooltime { get { return mobData.cooltime; } }
    public bool IsEnemy { get { return mobData.isEnemy; } }
}
