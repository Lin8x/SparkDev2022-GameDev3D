using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private GameObject healthText;
    private HealthText text;

    private void Start()
    {
        text = healthText.GetComponent<HealthText>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = text.enemyHealthValue;
    }
}
