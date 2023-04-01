using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject Menu;

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

    void Start()
    {
        Menu.SetActive(false);
    }

    public void OnPlayerDeath()
    {
        Menu.SetActive(true);
    }

    public void RetryButton()
    {
        Inventory.instance.RemoveCoins(0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        PlayerHealth.instance.Respawn();

        Menu.SetActive(false);
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
