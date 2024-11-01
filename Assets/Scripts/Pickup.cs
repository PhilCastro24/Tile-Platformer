using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]AudioClip CoinPickupSFX;
    [SerializeField] int pointsForCoinPickup = 100;

    bool wasCollected = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !wasCollected)
        {
            wasCollected = true;
            FindObjectOfType<GameSession>().AddToScore(pointsForCoinPickup);
            AudioSource.PlayClipAtPoint(CoinPickupSFX, Camera.main.transform.position);
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
