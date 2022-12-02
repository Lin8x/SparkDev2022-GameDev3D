using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class storm_script : MonoBehaviour
{
    public GameObject player;
    public player_script player_health_script;
    public bool player_is_inside = false;

    public GameObject storm_particles;
    public GameObject storm_ui;
    public float health_diminish = 1;
    public GameObject timer_text_go;
    public Text timer_text;
    public GameObject coughing_sound;
    public GameObject enemies;

    public GameObject stomg_go;
    public GameObject stomg_pos_1;
    public GameObject stomg_pos_2;
    public GameObject stomg_pos_3;

    public bool start_stom_rush = false;
    bool check_player = false;
    float timer_rush = 15;
    bool change_storm_pos = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            enemies.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            player_is_inside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            player_is_inside = false;
        }
    }


    void Update()
    {

        if(start_stom_rush == false)
        {
            timer_text_go.SetActive(false);
            change_storm_pos = false;
        }
        if (start_stom_rush == true)
        {
            timer_text_go.SetActive(true);

            int r_int = Random.Range(0, 3);
            if(r_int == 0 && change_storm_pos == false)
            {
                stomg_go.transform.position = stomg_pos_1.transform.position;
                change_storm_pos = true;
            }
            if (r_int == 1 && change_storm_pos == false)
            {
                stomg_go.transform.position = stomg_pos_2.transform.position;
                change_storm_pos = true;
            }
            if (r_int == 2 && change_storm_pos == false)
            {
                stomg_go.transform.position = stomg_pos_3.transform.position;
                change_storm_pos = true;
            }         
        }


        timer_text.text = Mathf.RoundToInt(timer_rush).ToString();
        if (start_stom_rush == true)
        {
            timer_rush = timer_rush - Time.deltaTime;
            if (timer_rush <= 0)
            {
                start_stom_rush = false;
                timer_rush = 15;
                check_player = true;
            }
        }


        if(player_is_inside == false && check_player == true && start_stom_rush == false)
        {
            coughing_sound.SetActive(true);
            player_health_script.health = (player_health_script.health - Time.deltaTime* health_diminish);
            storm_particles.SetActive(true);
            storm_ui.SetActive(true);
        }
        if(player_is_inside == true || start_stom_rush == true)
        {
            coughing_sound.SetActive(false);
            storm_particles.SetActive(false);
            storm_ui.SetActive(false);
        }
       
    }
}
