using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coinExpireTimer;

    // Update is called once per frame
    void Update()
    {
            Destroy(gameObject, coinExpireTimer);
    }

    // other collider triggered player's collider
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject other = collider.gameObject;
        if (Layers.Instance.player.Contains(other))
        {
            Die();
        }
    }

    // die and add points if awarded
    private void Die()
    {
        Destroy(gameObject);
        GameManager.Instance.ScoreCoin();
    }
}
