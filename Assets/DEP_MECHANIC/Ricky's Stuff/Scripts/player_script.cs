using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{
    public float health = 100;
    public Text health_text;
    public Rigidbody player_rig;
    public AudioSource foot_steps;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player_move_script;

    float walk_timer = 0.45f;
    bool start_walk_timer = false;
    float walk_timer_reset = 0.45f;
    public float stamina = 10;

    void Update()
    {

        health_text.text = "Health: " + Mathf.RoundToInt(health).ToString();
        if (health <= 0)
        {

        }

        //Walk Timer
        if (start_walk_timer == true)
        {
            walk_timer = walk_timer - Time.deltaTime;
            if (walk_timer <= 0)
            {
                walk_timer = walk_timer_reset;
                start_walk_timer = false;
            }
        }

        //Player Sprint
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina = stamina - Time.deltaTime;
            walk_timer_reset = 0.28f;        
        }
        else
        {
            //Stamina Regen
            if (stamina < 10)
            {
                stamina = stamina + Time.deltaTime * 1.5f;
            }
            walk_timer_reset = 0.45f;          
        }

        //Footstep Sounds
        if (player_rig.velocity.x > 0.5 || player_rig.velocity.y > 0.5
       || player_rig.velocity.y < -0.5 || player_rig.velocity.x < -0.5)
        {
            if (player_move_script.Grounded == true && start_walk_timer == false)
            {
                foot_steps.pitch = 0.7f;
                float num = Random.Range(0.1f, 0.5f);
                foot_steps.pitch = foot_steps.pitch + num;
                foot_steps.Play();
                start_walk_timer = true;
            }
        }

    }
}
