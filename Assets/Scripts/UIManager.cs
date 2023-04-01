using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TMP_Text score_joueur;

    public void AfficherMenuGameOver(int p_score)
    {
        if (PlayerPrefs.GetInt("score") < p_score)
            PlayerPrefs.SetInt("score", p_score);

        score_joueur.text = "Meilleur score : " + PlayerPrefs.GetInt("score");
    }
}
