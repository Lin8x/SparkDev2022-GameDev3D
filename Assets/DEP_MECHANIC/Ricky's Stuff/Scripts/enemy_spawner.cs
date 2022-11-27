using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy_spawner : MonoBehaviour
{

    public GameObject enemy_object;
    public GameObject enemy_reset_position;
    public GameObject player;
    public NavMeshAgent enemy_agent;
    public Animator slender_animator;
    public float enemy_health = 100;
    public GameObject blood_ui;
    public GameObject slender_glitch;
    public player_script playerscript;
    public float damage_amount = 2;
    public AudioSource hit_sound_2;
    public AudioSource growl_sound;
    public GameObject action_music;
    public disable_item action_music_disable_component;
    public GameObject drops;
    bool start_reset_timer = false;
    float reset_timer = 5f;
    public bool following_playuer = false;
    
    public AudioSource hit_sound;

    public void take_damage(float damage)
    {
        enemy_health = enemy_health - damage;
        hit_sound.Play();
        hit_sound_2.Play();
    }

    void Update()
    {
        //RESPAWN TIMER
        if(start_reset_timer == true)
        {
            reset_timer = reset_timer - Time.deltaTime;
            if (reset_timer <= 0)
            {
                enemy_health = 100;
                enemy_object.SetActive(true);
                start_reset_timer = false;
                reset_timer = 5;
            }
        }

        //RESPAWN ENEMY
        if(enemy_health <= 0 && start_reset_timer == false)
        {
            Instantiate(drops, enemy_object.transform.position, enemy_object.transform.rotation);
            enemy_object.SetActive(false);
            enemy_object.transform.position = enemy_reset_position.transform.position;
            start_reset_timer = true;
        }
    
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) < 2)
        {
            //ATTACK PLAYER
            blood_ui.SetActive(true);
           // slender_glitch.SetActive(true);
            slender_animator.SetInteger("state", 2);
            playerscript.health = playerscript.health - Time.deltaTime * damage_amount;
            //enemy_agent.SetDestination(this.transform.position);                       
        }
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) > 3 && Vector3.Distance(enemy_object.transform.position, player.transform.position) < 20)
        {
            //FOLLOW PLAYER
            if (following_playuer == false)
            {
                growl_sound.Play();
                following_playuer = true;
            }
            action_music_disable_component.timer_to_disable = 2;
            action_music.SetActive(true);
            enemy_object.transform.LookAt(player.transform.position);
            slender_animator.SetInteger("state", 1);
            enemy_agent.SetDestination(player.transform.position);                      
        }
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) > 20)
        {
            following_playuer = false;         
            //RANDOM LOCATION
            // enemy_agent.SetDestination(this.transform.position);                  
        }
    }


    private void OnAnimatorIK(int layerIndex)
    {
        slender_animator.SetLookAtPosition(player.transform.position);
        slender_animator.SetLookAtWeight(1);
    }


}
