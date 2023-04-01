using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrendrePiece : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory.instance.AddCoins();
            Destroy(gameObject);
        }
    }
}
