using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ricky_Game_Script : MonoBehaviour
{
    public PlayerMove player_move_script;
    public Rigidbody player_rig;
    public float jump_force = 500;
    public GameObject bullet_object;
    public Transform bullet_in_gun_position;
    public float bullet_speed;
    public AudioSource gun_sound;
    public Animator gun_animator;
    public float gun_impact = 20;
    public AudioSource double_jump_sound;
    public AudioSource foot_steps;

    float jump_timer = 3f;
    float walk_timer = 0.45f;
    bool start_walk_timer = false;
    bool start_jump_timer = false;

    void Update()
    {
        if(start_walk_timer == true)
        {
            walk_timer = walk_timer - Time.deltaTime;
            if (walk_timer <= 0)
            {
                walk_timer = 0.45f;
                start_walk_timer = false;
            }
        }

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
        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            player_move_script.moveSpeed = 15;
        }
        else
        {
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
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(player_move_script.grounded == true)
            {
                player_rig.AddForce(-bullet_in_gun_position.transform.forward * gun_impact);
            }
          
           GameObject bullet = Instantiate(bullet_object, bullet_in_gun_position.position, bullet_in_gun_position.rotation);
           Rigidbody bullet_rig = bullet.GetComponent<Rigidbody>();
           bullet_rig.AddForce(bullet_in_gun_position.transform.forward * bullet_speed);
           gun_animator.SetInteger("state", 1);
           gun_sound.Play();
        }
        else
        {
            gun_animator.SetInteger("state", 0);
        }
       



    }
}
