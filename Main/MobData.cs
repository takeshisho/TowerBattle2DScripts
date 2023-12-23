using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/MobData")]
public class MobData : ScriptableObject
{
    // TODO: 本当はserializeFieldにして、プロパティをこっちにも作る方が良いかな？
    [SerializeField] string mobName;     //キャラクターの名前
    public float hp;           //体力
    public float strength;     //攻撃力
    public float speed;        //素早さ
    public int cost;           //コスト
    public int cooltime;       //クールタイム
    public bool isEnemy;       //敵か味方か
    // public Sprite Icon;        //アイコン
    // AnimationClip[] Animations; //アニメーション
}
