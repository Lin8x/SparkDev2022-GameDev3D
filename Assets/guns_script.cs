using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guns_script : MonoBehaviour
{

    public GameObject shotgun;
    public GameObject pistol;

    public AudioSource shotgunsound_1;
    public AudioSource shotgunsound_2;
    public AudioSource pistol_sound_1;
    public AudioSource pistol_sound_2;
    public AudioSource reload_sound;
    public AudioSource switch_gun_sound;

    public Animator shotgun_animator;
    public Animator pistol_animator;

    public ParticleSystem shotgun_particle;
    public ParticleSystem pistol_particle;


    bool start_fire_rate = false;
    float fire_Rate = 0.8f;
    float fire_rate_reset = 0.8f;

    void Update()
    {

        if(start_fire_rate == true)
        {
            fire_Rate = fire_Rate - Time.deltaTime;
            if (fire_Rate <= 0)
            {
                shotgun_animator.SetInteger("state", 0);
                pistol_animator.SetInteger("state", 0);
                start_fire_rate = false;
                fire_Rate = fire_rate_reset;
            }
        }


        if (Input.GetKeyDown("1"))
        {
            switch_gun_sound.Play();
            if (shotgun.activeInHierarchy == true)
            {
                shotgun.SetActive(false);
            }
            else if (shotgun.activeInHierarchy == false)
            {
                shotgun.SetActive(true);
                pistol.SetActive(false);
            }  
        }
        if (Input.GetKeyDown("2"))
        {
            switch_gun_sound.Play();
            if (pistol.activeInHierarchy == true)
            {
                pistol.SetActive(false);
            }
            else if (pistol.activeInHierarchy == false)
            {
                shotgun.SetActive(false);
                pistol.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.Mouse0) && start_fire_rate == false)
        {
            fire_rate_reset = 0.7f;
            if (shotgun.activeInHierarchy == true && shotgun_animator.GetInteger("state") != 1)
            {
                int choose = Random.Range(0, 2);
                if(choose == 0)
                {
                    shotgunsound_1.Play();
                }
                else
                {
                    shotgunsound_2.Play();
                }
                shotgun_particle.Play();
                shotgun_animator.SetInteger("state", 1);
                start_fire_rate = true;
            }
            if (pistol.activeInHierarchy == true && pistol_animator.GetInteger("state") != 1)
            {
                fire_rate_reset = 0.45f;
                int choose = Random.Range(0, 2);
                if (choose == 0)
                {
                    pistol_sound_1.Play();
                }
                else
                {
                    pistol_sound_2.Play();
                }
                pistol_particle.Play();
                pistol_animator.SetInteger("state", 1);
                start_fire_rate = true;
            }
        }


        if (Input.GetKeyDown("r"))
        {
            if (shotgun.activeInHierarchy == true)
            {
                shotgun_animator.SetInteger("state", 2);
            }

            if (pistol.activeInHierarchy == true)
            {
                pistol_animator.SetInteger("state", 2);
            }
            reload_sound.Play();
            start_fire_rate = true;
        }
    }
}
