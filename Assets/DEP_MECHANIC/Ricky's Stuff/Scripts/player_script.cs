using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class player_script : MonoBehaviour
{
    public float health = 100;
    public Text health_text;
    public Slider healthBar;
    public Text stamina_text;
    public Slider staminaBar;
    public Rigidbody player_rig;
    public AudioSource foot_steps;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player_move_script;
    public GameObject health_alert;
    public GameObject stamina_alert;
    public AudioSource question_mark_sound_pickup;
    public AudioSource health_sound_pickup;
    public int question_mark_pickup = 0;
    public Text question_text;
    public int total_kills = 0;
    public Text kills_score;
    public GameObject score_kill_ob;
    public Text score_kill_ob_text;
    public Text high_score_text;
    public Text death_kills_count;
    public Text death_highest_score_text;

    int highest_Score = 0;
    float walk_timer = 0.45f;
    bool start_walk_timer = false;
    float walk_timer_reset = 0.45f;
    public float stamina = 10;

    public void kill_enemy()
    {
        score_kill_ob.SetActive(true);
        total_kills = total_kills + 1;
    }

    public void pickup_drops(int drop)
    {
        if(drop == 1)
        {
            question_mark_pickup = question_mark_pickup + 1;
            question_mark_sound_pickup.Play();
        }
        if (drop == 2)
        {
            health = health + Random.Range(10, 50);
            health_sound_pickup.Play();
        }
    }

    private void Start()
    {
        highest_Score = PlayerPrefs.GetInt("high score");
    }

    void Update()
    {
        if (highest_Score < total_kills)
        {          
            highest_Score = total_kills;
            PlayerPrefs.SetInt("high score", highest_Score);
        }
        death_kills_count.text = "YOUR SCORE - " + total_kills.ToString();
        death_highest_score_text.text = "BEST SCORE - " + highest_Score.ToString();
        high_score_text.text = "BEST SCORE - " + highest_Score.ToString();
        score_kill_ob_text.text = total_kills.ToString();
        kills_score.text = total_kills.ToString();
        question_text.text = question_mark_pickup.ToString();

        if (health > 100)
        {
            health = 100;
        }

        if(health < 15)
        {
            health_alert.SetActive(true);
        }
        else
        {
            health_alert.SetActive(false);
        }
        if(stamina < 2)
        {
            stamina_alert.SetActive(true);
        }
        else
        {
            stamina_alert.SetActive(false);
        }

        health_text.text = Mathf.RoundToInt(health).ToString();
        healthBar.value = Mathf.RoundToInt(health);
        stamina_text.text = Mathf.RoundToInt(stamina).ToString();
        staminaBar.value = Mathf.RoundToInt(stamina);
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
