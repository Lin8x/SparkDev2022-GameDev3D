using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guns_script : MonoBehaviour
{

    public GameObject shotgun;
    public GameObject pistol;
    public GameObject shotgun_bullet;
    public GameObject pistol_bullet;
    public GameObject shotgun_bullet_location;
    public GameObject pistol_bullet_location;

    public float bullet_force = 250;

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
                if(shotgun.activeInHierarchy == true)
                {
                    shotgun_animator.SetInteger("state", 0);
                }
                if (pistol.activeInHierarchy == true)
                {
                    pistol_animator.SetInteger("state", 0);
                }              
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
            shotgun_animator.speed = 3;
            fire_rate_reset = 0.35f;         
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
                GameObject bullet = Instantiate(shotgun_bullet, shotgun_bullet_location.transform.position, shotgun_bullet_location.transform.rotation);
                Rigidbody bullet_rig = bullet.GetComponent<Rigidbody>();
                bullet_rig.AddForce(shotgun.transform.forward * bullet_force);
                shotgun_particle.Play();
                shotgun_animator.SetInteger("state", 1);
                start_fire_rate = true;
            }
            if (pistol.activeInHierarchy == true && pistol_animator.GetInteger("state") != 1)
            {
                pistol_animator.speed = 3;
                fire_rate_reset = 0.17f;
                int choose = Random.Range(0, 2);
                if (choose == 0)
                {
                    pistol_sound_1.Play();
                }
                else
                {
                    pistol_sound_2.Play();
                }
                GameObject bullet = Instantiate(pistol_bullet, pistol_bullet_location.transform.position, pistol_bullet_location.transform.rotation);
                Rigidbody bullet_rig = bullet.GetComponent<Rigidbody>();
                bullet_rig.AddForce(shotgun.transform.forward * bullet_force);
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
