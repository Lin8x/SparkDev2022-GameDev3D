using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_drops : MonoBehaviour
{

    public GameObject health;
    public GameObject ammo;
    public GameObject question;
    player_script script_player;
    guns_script script_guns;

    private void Start()
    {
        int ran = Random.Range(0, 3);
        if(ran == 0)
        {
            health.SetActive(true);
            ammo.SetActive(false);
            question.SetActive(false);
        }
        if (ran == 1)
        {
            health.SetActive(false);
            ammo.SetActive(true);
            question.SetActive(false);
        }
        if (ran == 2)
        {
            health.SetActive(false);
            ammo.SetActive(false);
            question.SetActive(true);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            script_player = other.gameObject.GetComponent<player_script>();
            script_guns = other.gameObject.GetComponent<guns_script>();

            if (health.activeInHierarchy == true && script_player !=null)
            {
                script_player.pickup_drops(2);
                Destroy(this.gameObject);
            }
            if (question.activeInHierarchy == true && script_player != null)
            {
                script_player.pickup_drops(1);
                Destroy(this.gameObject);
            }
            if (ammo.activeInHierarchy == true && script_guns !=null)
            {
                script_guns.pickup_ammo();
                Destroy(this.gameObject);
            }
           
        }
    }
}
