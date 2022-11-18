using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dan_maps : MonoBehaviour
{
    public GameObject storm_object;
    public GameObject object_to_look;

    void Update()
    {
        if(Vector3.Distance(object_to_look.transform.position, storm_object.transform.position) < 30)
        {
            object_to_look.SetActive(false);
        }
        if (Vector3.Distance(object_to_look.transform.position, storm_object.transform.position) >= 30)
        {
            object_to_look.SetActive(true);
        }

        object_to_look.transform.LookAt(storm_object.transform.position);
    }
}
