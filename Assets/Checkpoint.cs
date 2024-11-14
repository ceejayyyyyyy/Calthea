using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public GameController gameController;
    public Transform respawnPoint;

    SpriteRenderer spriteRenderer;
    public Sprite passive, active;

    private void Awake()
    {
        // Optional: Find the GameController automatically
        if (gameController == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            spriteRenderer = GetComponent<SpriteRenderer>();
            if (player != null)
            {
                gameController = player.GetComponent<GameController>();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameController.UpdateCheckpoint(respawnPoint.position);
            Debug.Log("Checkpoint activated!");
            spriteRenderer.sprite = active;
        }
    }
}
