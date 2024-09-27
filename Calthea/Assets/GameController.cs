using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    Vector2 checkpointPos;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rb;
    public DeathCounter deathCounter;
    public PlayerDeathHandler playerDeathHandler;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        checkpointPos = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    public void UpdateCheckpoint(Vector2 pos)
    {
        checkpointPos = pos;
    }

    void Die()
    {
        if (playerDeathHandler != null)
        {
            playerDeathHandler.OnPlayerDeath();
        }
        if (deathCounter != null)
        {
            deathCounter.IncreaseDeathCount();
        }
        StartCoroutine(Respawn(0.5f));
    }

    IEnumerator Respawn(float duration)
    {
        rb.simulated = false;
        rb.velocity = Vector2.zero;
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = checkpointPos;
        spriteRenderer.enabled = true;
        rb.simulated = true;
    }
}