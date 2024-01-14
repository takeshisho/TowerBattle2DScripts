using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cost : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI costText;
    private float accumulatedTime = 0.0f;
    public int GameCost = 0;
    public static Cost Instance { get; private set; }
    private const int MAX_COST = 9999;
    private const float GameCostPerSecond = 30.0f;

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
        costText.text = GameCost.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        if(GameCost >= MAX_COST) return;

        accumulatedTime += Time.deltaTime;
        if (accumulatedTime >= 1.0f / GameCostPerSecond) // Check if 1/60th of a second has passed
        {
            GameCost += (int)(GameCostPerSecond * accumulatedTime); // Increase GameCost by 60 times the accumulated time
            accumulatedTime -= 1.0f / GameCostPerSecond; // Subtract 1/60th of a second from the accumulated time
        }
        costText.text = GameCost.ToString();
    }

    public void UseCost(int cost)
    {
        GameCost -= cost;
    }
}
