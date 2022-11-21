using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ricky_ai : MonoBehaviour
{
    public NavMeshAgent this_agent;
    public GameObject player;
    public Animator this_animator;
    public player_script playerscript;
    public GameObject slender_noise;
    public GameObject blood_damage_image;
    /* public Image blood_image_ui;
     public Color blood_image_color;
     public Color blood_image_color_reset;*/

    public bool ragdoll_death = false;
    public GameObject slender_model;
    public GameObject slender_model_ragdoll;
    public Rigidbody ragdoll_rig;

    float health_timer = 2;
    bool start_health_timer = false;


    public void follow_player()
    {
        if (this_agent.hasPath == true)
        {
           
        }
        slender_noise.SetActive(false);
        this_agent.SetDestination(player.transform.position);
        this_animator.SetInteger("state", 1);
    }

    public void idle()
    {
        slender_noise.SetActive(false);
        if (this_agent.hasPath == true)
        {
            this_agent.SetDestination(this.transform.position);
            this_animator.SetInteger("state", 0);
        }
    }

    public void attack()
    {
        if(start_health_timer == false)
        {
            // blood_image_ui.color = blood_image_color_reset;
            //blood_damage_image.SetActive(true);
            playerscript.health = playerscript.health - 20;
            start_health_timer = true;
        }
        slender_noise.SetActive(true);
        this_agent.SetDestination(this.transform.position);
        this_animator.SetInteger("state", 2);
    }

    void Update()
    {

        if(ragdoll_death == true)
        {
            //ragdoll_rig.AddForce(this.transform.up * 5000);
            slender_model_ragdoll.SetActive(false);
            slender_model_ragdoll.transform.position = slender_model.transform.position;
            slender_model_ragdoll.transform.position = new Vector3(slender_model_ragdoll.transform.position.x, slender_model_ragdoll.transform.position.y+2, slender_model_ragdoll.transform.position.z);
            slender_model_ragdoll.SetActive(true);
            slender_model.gameObject.SetActive(false);
        }

       /* if (blood_damage_image.activeInHierarchy == true)
        {
            blood_image_color.a = blood_image_color.a - (Time.deltaTime/3.5f);
            blood_image_ui.color = blood_image_color;
        }*/

        // Damage Player Timer
        if(start_health_timer== true)
        {
            health_timer = health_timer - Time.deltaTime;
            if (health_timer <= 0)
            {
                health_timer = 2;
                start_health_timer = false;
            }
        }

       
        if (Vector3.Distance(this.transform.position, player.transform.position) < 10 && Vector3.Distance(this.transform.position, player.transform.position) > 3)
        {           
            follow_player();           
        }
        else if(Vector3.Distance(this.transform.position, player.transform.position) > 10)
        {
            idle();         
        }
        else if (Vector3.Distance(this.transform.position, player.transform.position) <= 3)
        {
            attack();         
        }
    }
}
