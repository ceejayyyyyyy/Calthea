using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DeathCounter : MonoBehaviour
{
    private int deathCount;

    public void IncreaseDeathCount()
    {
        deathCount++;
    }

    public int GetDeathCount()
    {
        return deathCount;
    }

    public void SendDeathCountToServer()
    {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        formData.Add(new MultipartFormDataSection("death_count", deathCount.ToString()));

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/game_api/update_deaths.php", formData))
        {
            www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + www.error);
            }
            else
            {
                Debug.Log("Form upload complete!");
            }
        }
    }
}