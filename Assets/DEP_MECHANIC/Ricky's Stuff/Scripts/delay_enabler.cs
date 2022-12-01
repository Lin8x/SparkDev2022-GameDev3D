using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delay_enabler : MonoBehaviour
{
    public GameObject item_to_enable_1;
    public GameObject item_to_enable_2;
    public GameObject item_to_enable_3;
    public GameObject item_to_enable_4;
    public GameObject item_to_enable_5;


    float timer = 5;

    void Update()
    {
        timer = timer - Time.deltaTime;

        if (timer <= 4.5f)
        {
            item_to_enable_1.SetActive(true);
        }
        if (timer <= 4)
        {
            item_to_enable_2.SetActive(true);
        }
        if (timer <= 3)
        {
            item_to_enable_3.SetActive(true);
        }
        if (timer <= 2)
        {
            item_to_enable_4.SetActive(true);
        }
        if (timer <= 1)
        {
            item_to_enable_5.SetActive(true);
        }


    }
}
