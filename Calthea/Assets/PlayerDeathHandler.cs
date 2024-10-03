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
        Debug.Log("OnPlayerDeath method called");
        if (deathCounter != null)
        {
            Debug.Log("Death count before update: " + deathCounter.GetDeathCount());
            deathCounter.IncreaseDeathCount();
            Debug.Log("Death count after update: " + deathCounter.GetDeathCount());
            deathCounter.SendDeathCountToServer();
        }
        else
        {
            Debug.LogError("DeathCounter component not found!");
        }
    }
}