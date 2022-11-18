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

    public float enemy_health = 100;

    bool start_reset_timer = false;
    float reset_timer = 5f;

    public AudioSource hit_sound;

    public void take_damage(float damage)
    {
        enemy_health = enemy_health - damage;
        hit_sound.Play();
    }

    void Update()
    {
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

        if(enemy_health <= 0 && start_reset_timer == false)
        {
            enemy_object.SetActive(false);
            enemy_object.transform.position = enemy_reset_position.transform.position;
            start_reset_timer = true;
        }


        //FOLLOW PLAYER
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) <= 5)
        {
            if (enemy_agent.hasPath == true)
            {
                enemy_agent.SetDestination(this.transform.position);
            }               
        }
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) > 5 && Vector3.Distance(enemy_object.transform.position, player.transform.position) < 20)
        {
            if (enemy_agent.hasPath == true)
            {
                enemy_agent.SetDestination(player.transform.position);
            }              
        }
        if (Vector3.Distance(enemy_object.transform.position, player.transform.position) > 20)
        {
            if(enemy_agent.hasPath == true)
            {
                enemy_agent.SetDestination(this.transform.position);
            }        
        }




    }
}
