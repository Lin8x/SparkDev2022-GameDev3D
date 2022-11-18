using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{
    public float health = 100;
    public Text health_text;

    void Update()
    {
        health_text.text = "Health: " + Mathf.RoundToInt(health).ToString();
        if (health <= 0)
        {

        }
    }
}
