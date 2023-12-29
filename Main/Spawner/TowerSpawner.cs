using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyTowerPrefabs;

    // TODO: Spawnerが体力のテキストを保持するのはおかしいので、うまく直したい
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
        // ゲームクリア
        Debug.Log("<color=blue>Game WIN!</color>");
        SceneManager.LoadScene("GameWinScene");
    }

    // TODO: 生成時にHPを設定するテキストにセットしたい。今は雑に設定している。
    private void TowerSpawn() 
    {
        GameObject nextTower = Instantiate(enemyTowerPrefabs[enemyTowerIndex], transform.position, Quaternion.identity);
        nextTower.GetComponent<TowerHitPoint>().HpText = EnemyTowerHPText;
        // 元々はstartに書いていたが、prefabは生成した後しか、actionをセットできないのでここへ移動
        nextTower.GetComponent<TowerHitPoint>().TowerSpawnAction = CheckNextTowerSpawn;

        var transformCache = nextTower.transform;
        var defaultPosition = transformCache.position;
        var firstPosition = defaultPosition + new Vector3(0, 5f, 0);
        transformCache.position = firstPosition;
        transformCache.DOLocalMove(defaultPosition, 1f);
    }
}
