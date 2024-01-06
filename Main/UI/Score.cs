using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int GameScore = 0;
    public int DestroyedCastleNum = 0;
    public int DefeatedEnemyNum = 0;

    // 下でシングルトンしているので、Score唯一のインスタンスを取得するためのプロパティになる。
    // これにより、全て共通のScoreインスタンスを参照することができる。
    public static Score Instance { get; private set; }

    // シングルトン
    private void Awake()
    {
        // シングルトンの呪文
        if (Instance == null)
        {
            // 自身をインスタンスとする
            Instance = this;
        }
        else
        {
            // インスタンスが複数存在しないように、既に存在していたら自身を消去する
            Destroy(gameObject);
        }
        scoreText.text = DestroyedCastleNum.ToString();
    }

    private void Start() {
        Debug.Log("GameScore: " + GameScore + " DestroyedCastleNum: " + DestroyedCastleNum + " DefeatedEnemyNum: " + DefeatedEnemyNum);
    }

    public void AddScore(int score = 1)
    {
        // TODO: スコアをどのように決めるか考える
        GameScore = DefeatedEnemyNum + DestroyedCastleNum * 10;
    }

    public void AddDestroyedCastleNum()
    {
        DestroyedCastleNum += 1;
        scoreText.text = DestroyedCastleNum.ToString();
    }

    public void AddDefeatedEnemyNum()
    {
        DefeatedEnemyNum += 1;
    }

}
