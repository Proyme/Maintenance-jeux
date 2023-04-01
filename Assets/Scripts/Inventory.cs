using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public int coinsCount;
    public Text coinsCountText;

    public static Inventory instance;

    public Text scoreText;

    private void Awake()
    {

        if (instance != null)
        {
            //Debug.LogWarning("oui inv");
            return;
        }

        instance = this;
    }

    public void AddCoins()
    {
        Debug.Log("plus 1 piece");
        int previousCount = coinsCount;
        coinsCount ++;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int coin)
    {
        coinsCount = coin;
        coinsCountText.text = coinsCount.ToString();
    }
}
