using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameObject coinSprite;
    private int _coinValue = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            Inventory.Instance.AddCoins(_coinValue);
            Destroy(gameObject);
        }
    }
}