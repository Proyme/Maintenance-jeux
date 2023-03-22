using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverUI;

    public static GameOver instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'instance");
            return;
        }
        instance = this;
    }

    public void OnPlayerDeath()
    {
        gameOverUI.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(CurrentSceneManager.instance.coinsPickedUpCount);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerHealth.instance.Respawn();

        gameOverUI.SetActive(false);
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
