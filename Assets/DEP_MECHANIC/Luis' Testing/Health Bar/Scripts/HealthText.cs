using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField]
    GameObject enemyHealthBar;
    private TMP_Text enemyHealtText;
    public float enemyHealthValue = 100;
    [SerializeField]
    private GameObject myEnemy;
    private enemy_spawner enemySript;

    void Start()
    {
        myEnemy = myEnemy.transform.parent.parent.parent.gameObject;
        enemyHealtText = enemyHealthBar.GetComponent<TMP_Text>();
        enemySript = myEnemy.GetComponent<enemy_spawner>();
    }

    void Update()
    {
        enemyHealthValue = enemySript.enemy_health;
        enemyHealtText.text = Mathf.RoundToInt(enemyHealthValue).ToString();
    }
}
