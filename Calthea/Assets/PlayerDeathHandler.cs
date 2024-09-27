using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private DeathCounter deathCounter;

    void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
        Debug.Log("DeathCounter found: " + (deathCounter != null));
    }

    public void OnPlayerDeath()
    {
        Debug.Log("OnPlayerDeath called");
        if (deathCounter != null)
        {
            deathCounter.IncreaseDeathCount();
            deathCounter.SendDeathCountToServer();
        }
        else
        {
            Debug.LogError("DeathCounter component not found!");
        }
    }
}