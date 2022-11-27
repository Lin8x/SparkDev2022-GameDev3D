using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_object : MonoBehaviour
{
    public float timer_to_destroy;
    public GameObject object_to_destrou;

    void Update()
    {
        timer_to_destroy = timer_to_destroy - Time.deltaTime;
        if(timer_to_destroy <= 0)
        {
            Destroy(object_to_destrou);
        }
    }
}
