using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public int coinsPickedUpCount;

    public static CurrentSceneManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Plus d'instance");
            return;
        }
        instance = this;
    }
}
