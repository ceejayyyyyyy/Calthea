using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class DeathCounter : MonoBehaviour
{
    private int deathCount = 0;

    public void IncreaseDeathCount()
    {
        Debug.Log("IncreaseDeathCount called");
        deathCount++;
        Debug.Log("Death count incremented: " + deathCount);
        StartCoroutine(SendDeathCount(deathCount));
    }

    IEnumerator SendDeathCount(int count)
    {
        Debug.Log("SendDeathCount coroutine started");
        WWWForm form = new WWWForm();
        form.AddField("death_count", count);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/game_api/update_deaths.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Error: " + www.error);
            }
            else
            {
                Debug.Log("Death count updated successfully");
                Debug.Log("Response: " + www.downloadHandler.text);
            }
        }
    }
}
