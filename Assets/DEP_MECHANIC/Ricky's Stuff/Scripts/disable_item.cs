using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disable_item : MonoBehaviour
{
    public GameObject object_to_disable;
    public float timer_to_disable = 2;
    public float timer_to_reset = 2;


    void Update()
    {
        timer_to_disable = timer_to_disable - Time.deltaTime;
        if (timer_to_disable <= 0)
        {
            timer_to_disable = timer_to_reset;
            object_to_disable.SetActive(false);
        }
    }
}
