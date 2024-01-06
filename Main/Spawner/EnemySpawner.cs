using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    
    private void Start() {
        StartCoroutine(EnemySpawn());
    }

    private IEnumerator EnemySpawn() {
        while(true) {
            yield return new WaitForSeconds(5.0f);
            int enemyIndex = Random.Range(0, enemyPrefabs.Length);
            Instantiate(enemyPrefabs[enemyIndex], transform.position, Quaternion.identity);
        }
    }
}
