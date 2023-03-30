using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coin;

    public Vector3 center;
    public Vector3 size;

    void Start()
    {
        SpawnCoin();
    }

    public void SpawnCoin()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2));

        Instantiate(coin, pos, Quaternion.identity);

        //Debug.Log("Piecceeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, 5f);
        Gizmos.DrawCube(center, size);
    }

    void Update()
    {
        if (GameObject.FindWithTag("coin") == null)
        {
            SpawnCoin();
        }

        if (Input.GetKey(KeyCode.Q))
        {
            SpawnCoin();
        }
    }
}