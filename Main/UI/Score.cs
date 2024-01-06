using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int GameScore = 0;
    public int DestroyedCastleNum = 0;
    public int DefeatedEnemyNum = 0;

    public static Score Instance { get; private set; }

    // シングルトン
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        scoreText.text = DestroyedCastleNum.ToString();
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
