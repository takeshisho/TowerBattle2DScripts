using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyTowerPrefabs;
    [SerializeField] TextMeshProUGUI EnemyTowerHPText;
    private int enemyTowerIndex = 0;

    private void Start() 
    {
        TowerSpawn();
    }

    private void CheckNextTowerSpawn() 
    {
        enemyTowerIndex++;

        if (enemyTowerIndex >= enemyTowerPrefabs.Length) GameWin();
        else TowerSpawn();
    }

    private void GameWin() 
    {
        Debug.Log("<color=blue>Game WIN!</color>");
        SceneManager.LoadScene("GameWinScene");
    }

    private void TowerSpawn() 
    {
        GameObject nextTower = Instantiate(enemyTowerPrefabs[enemyTowerIndex], transform.position, Quaternion.identity);
        nextTower.GetComponent<TowerHitPoint>().HpText = EnemyTowerHPText;
        nextTower.GetComponent<TowerHitPoint>().TowerSpawnAction = CheckNextTowerSpawn;

        // 簡易タワー生成アニメーション
        var transformCache = nextTower.transform;
        var defaultPosition = transformCache.position;
        var firstPosition = defaultPosition + new Vector3(0, 5f, 0);
        transformCache.position = firstPosition;
        transformCache.DOLocalMove(defaultPosition, 1f);
    }
}
