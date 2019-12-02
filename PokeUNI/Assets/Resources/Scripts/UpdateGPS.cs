using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPS : MonoBehaviour
{
    public Text coordinates;

    private void Update()
    {
        coordinates.text = "Latitud:" + GPS.Instance.latitude.ToString() + "\nLongitud: " + GPS.Instance.longitude.ToString();
    }
}
