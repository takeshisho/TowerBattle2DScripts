using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MobData")]
public class MobData : ScriptableObject
{
    // TODO: 本当はserializeFieldにして、プロパティをこっちにも作る方が良いかな？
    [SerializeField] string mobName;     
    public int maxHp;            
    public int damage;           
    public float speed;
    public int   cost;
    public float cooltime;
    public float AttackCooltime;
    public bool  isEnemy;
    // public Sprite Icon;       //アイコン
    // AnimationClip[] Animations; //アニメーション
}
