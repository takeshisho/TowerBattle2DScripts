using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerHitPoint : HitPoint
{
    
    public TextMeshProUGUI HpText;
    private int MaxHp;
    public System.Action TowerSpawnAction;

    protected override void Start() 
    {
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
        if(this.gameObject.tag == "Player")
        {
            Debug.Log("<color=blue>GAMEOVER!</color>");
            SceneManager.LoadScene("GameOverScene");

        }
        else if(this.gameObject.tag == "Enemy")
        {
            TowerSpawnAction?.Invoke();
            Score.Instance.AddDestroyedCastleNum();
        }
        
        //TODO: アニメーション生成
    }
}
