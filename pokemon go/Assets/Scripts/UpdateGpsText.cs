using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UpdateGpsText : MonoBehaviour
{
    public Text coordinates;
    private void Update()
    {
        coordinates.text = "Lat: " + Gps.Instance.latitude.ToString() + "  Lon:" + Gps.Instance.longtitude.ToString();
    }
}
