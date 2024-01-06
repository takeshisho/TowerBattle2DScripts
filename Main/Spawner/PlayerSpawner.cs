using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] PlayerSpawnerButton[] playerMobButtons;

    private void Start() 
    {
        for (int i = 0; i < playerMobButtons.Length; i++) 
        {
            playerMobButtons[i].onClickCallback = PlayerMobSpawn;
        }
    }

    private void PlayerMobSpawn(GameObject playerMobPrefab) 
    {
        Instantiate(playerMobPrefab, transform.position, Quaternion.identity);
    }
}
