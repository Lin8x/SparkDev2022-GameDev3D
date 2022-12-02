using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private GameObject myEnemy;
    private enemy_spawner enemySript;

    private void Start()
    {
        myEnemy = myEnemy.transform.parent.parent.parent.gameObject;
        enemySript = myEnemy.GetComponent<enemy_spawner>();
    }
    // Update is called once per frame
    void Update()
    {
        healthBar.value = enemySript.enemy_health;
    }
}