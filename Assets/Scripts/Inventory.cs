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
            int score = PlayerPrefs.GetInt("score");
            scoreText.text = "Score: " + score.ToString();
            return;
        }

        instance = this;
    }

    public void AddCoins(int count)
    {
        Debug.Log("plus 1 piece");
        coinsCount += count;
        coinsCountText.text = coinsCount.ToString();
    }

    public void RemoveCoins(int count)
    {
        coinsCount -= count;
        coinsCountText.text = coinsCount.ToString();
    }

    private void Update()
    {
        if (GameObject.Find("Player") == null)
        {
            PlayerPrefs.SetInt("Mailleur Score", coinsCount);
            PlayerPrefs.Save();
        }
    }
}
