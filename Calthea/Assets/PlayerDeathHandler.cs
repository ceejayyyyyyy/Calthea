using UnityEngine;

public class PlayerDeathHandler : MonoBehaviour
{
    private DeathCounter deathCounter;

    void Start()
    {
        deathCounter = FindObjectOfType<DeathCounter>();
    }

    public void OnPlayerDeath()
    {
        if (deathCounter != null)
        {
            deathCounter.IncreaseDeathCount();
        }
        else
        {
            Debug.LogError("DeathCounter component not found!");
        }
    }
}
