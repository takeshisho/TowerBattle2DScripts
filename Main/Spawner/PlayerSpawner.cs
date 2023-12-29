using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] PlayerSpawnerButton[] playerMobButtons;

    private void Start() 
    {
        for (int i = 0; i < playerMobButtons.Length; i++) {
            int index = i;
            playerMobButtons[i].onClickCallback = PlayerMobSpawn;
        }
    }

    private void PlayerMobSpawn(GameObject playerMobPrefab) 
    {
        Instantiate(playerMobPrefab, transform.position, Quaternion.identity);
    }
}
