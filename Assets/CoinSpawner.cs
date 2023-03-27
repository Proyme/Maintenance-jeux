using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCoin(swarmerInterval, swarmerPrefab));
    }

    private IEnumerator spawnCoin(float interval, GameObject coin)
    {
        yield return new WaitForSeconds(interval);
        GameObject newCoin = Instantiate(coin, new Vector3(Random.Range(-2f, 2), Random.Range(-2f, 2f), 0), Quaternion.identity);
        StartCoroutine(spawnCoin(interval, coin));
    }
}