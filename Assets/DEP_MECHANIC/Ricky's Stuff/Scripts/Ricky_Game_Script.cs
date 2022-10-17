using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ricky_Game_Script : MonoBehaviour
{
    //Player Stuff
    public PlayerMove player_move_script;
    public Rigidbody player_rig;
    
    //Objects
    public GameObject bullet_object;
    public Transform bullet_in_gun_position;

    //Adjusted Variables
    public float jump_force = 500;
    public float gun_impact = 20;
    public float bullet_speed;

    //Animator
    public Animator gun_animator;

    //Sounds
    public AudioSource gun_sound;  
    public AudioSource double_jump_sound;
    public AudioSource foot_steps;
    public AudioSource dry_gun_sound;
    public AudioSource reload_sound;

    //Player Variables
    public int health = 100;
    public float stamina = 10;
    public int ammo = 150;

    //UI Stuff
    public Slider health_slider;
    public Slider Stamina_slider;

    public Text health_text;
    public Text stamina_text;
    public Text ammo_text;

    //Private Variables
    float jump_timer = 3f;
    float walk_timer = 0.45f;
    bool start_walk_timer = false;
    bool start_jump_timer = false;
    float walk_timer_reset = 0.45f;
    float fire_rate = 0.25f;
    bool start_fire_rate = false;

    void Update()
    {
        //Player Dies
        if (health <= 0)
        {

        }

        //Update Stamina & Health UI
        health_slider.value = health;
        Stamina_slider.value = stamina;
        ammo_text.text = "Ammo: " + ammo.ToString();
        health_text.text = health.ToString();
        stamina_text.text = Mathf.RoundToInt(stamina).ToString();

        //Fire Rate
        if (start_fire_rate == true)
        {
            fire_rate = fire_rate - Time.deltaTime;
            if (fire_rate <= 0)
            {
                fire_rate = 0.25f;
                start_fire_rate = false;
            }
        }

        //Walk Timer
        if(start_walk_timer == true)
        {
            walk_timer = walk_timer - Time.deltaTime;
            if (walk_timer <= 0)
            {
                walk_timer = walk_timer_reset;
                start_walk_timer = false;
            }
        }

        //Footstep Sounds
        if(player_rig.velocity.x > 0.5 || player_rig.velocity.y > 0.5
       || player_rig.velocity.y < -0.5 || player_rig.velocity.x < -0.5)
        {
            if (player_move_script.grounded == true && start_walk_timer == false)
            {
                foot_steps.pitch = 0.7f;
                float num = Random.Range(0.1f, 0.5f);
                foot_steps.pitch = foot_steps.pitch + num;
                foot_steps.Play();
                start_walk_timer = true;
            }        
        }

        //Double Jump Timer
        if (start_jump_timer == true)
        {
            jump_timer = jump_timer - Time.deltaTime;
            if (jump_timer <= 0)
            {
                jump_timer = 3;
                start_jump_timer = false;
            }
        }
        
        //Player Sprint
        if (Input.GetKey(KeyCode.LeftShift) && stamina > 0)
        {
            stamina = stamina - Time.deltaTime;
            walk_timer_reset = 0.28f;
            player_move_script.moveSpeed = 15;
        }
        else
        {
            //Stamina Regen
            if(stamina < 10)
            {
                stamina = stamina + Time.deltaTime * 1.5f;
            }           
            walk_timer_reset = 0.45f;
            player_move_script.moveSpeed = 8;
        }

        //Double Jump
        if(player_move_script.grounded == false && start_jump_timer == false)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                double_jump_sound.Play();
                player_rig.AddForce(Vector3.up* jump_force);
                start_jump_timer = true;
            }
        }

        //shoot
        if (Input.GetKeyDown(KeyCode.Mouse0) && start_fire_rate == false && ammo > 0)
        {
            //Gun Recoil
            if(player_move_script.grounded == true)
            {
                player_rig.AddForce(-bullet_in_gun_position.transform.forward * gun_impact);
            }
           ammo = ammo - 1;
           start_fire_rate = true;
           GameObject bullet = Instantiate(bullet_object, bullet_in_gun_position.position, bullet_in_gun_position.rotation);
           Rigidbody bullet_rig = bullet.GetComponent<Rigidbody>();
           bullet_rig.AddForce(bullet_in_gun_position.transform.forward * bullet_speed);
           gun_animator.SetInteger("state", 1);
           gun_sound.Play();
        }
        else
        {
            //Out Of Ammo
            if (Input.GetKeyDown(KeyCode.Mouse0) && ammo <= 0)
            {
                dry_gun_sound.Play();
            }              
            gun_animator.SetInteger("state", 0);
        }

        //Reload
        if (Input.GetKeyDown("r") && start_fire_rate == false && ammo <=0)
        {
            start_fire_rate = true;
            reload_sound.Play();
            ammo = ammo + 8;
        }
       
    }
}
