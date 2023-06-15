using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gps : MonoBehaviour
{
    public static Gps Instance { set; get; }

    public float latitude;
    public float longtitude;
    void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }
    private IEnumerator StartLocationService()
    {
        if (!Input.location.isEnabledByUser)
        {
            Debug.Log("User has not enabled GPS");
            yield break;
        }

        Input.location.Start();
        int maxWait = 10;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait <= 0)
        {
            Debug.Log("Timed out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed)
        {
            Debug.Log("Unable to determin device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longtitude = Input.location.lastData.longitude;

        yield break;
    }
}
