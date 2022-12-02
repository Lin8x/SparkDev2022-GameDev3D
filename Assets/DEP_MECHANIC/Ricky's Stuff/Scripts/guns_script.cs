using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class guns_script : MonoBehaviour
{

    public GameObject shotgun;
    public GameObject pistol;
    public GameObject shotgun_bullet;
    public GameObject pistol_bullet;
    public GameObject shotgun_bullet_location;
    public GameObject pistol_bullet_location;

    public float bullet_force = 250;
    public int shotgun_bullets = 8;
    public int pistol_bullets = 15;
    public int all_bullets = 500;

    public AudioSource shotgunsound_1;
    public AudioSource shotgunsound_2;
    public AudioSource pistol_sound_1;
    public AudioSource pistol_sound_2;
    public AudioSource reload_sound;
    public AudioSource switch_gun_sound;
    public AudioSource dry_fire;

    public Animator shotgun_animator;
    public Animator pistol_animator;

    public ParticleSystem shotgun_particle;
    public ParticleSystem pistol_particle;

    public Text current_bullet_text;
    public Text all_bullet_text;
    public GameObject bullets_alert;
    public AudioSource ammo_pickup_sound;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController fps_cam;
    public float cam_lerp = 0.1f;
    public AudioSource aim_sound;
    public AudioSource pistol_reload;

    bool start_fire_rate = false;
    float fire_Rate = 0.8f;
    float fire_rate_reset = 0.8f;

    public void pickup_ammo()
    {
        all_bullets = all_bullets + Random.Range(20, 80);
        ammo_pickup_sound.Play();
    }


    void Update()
    {     
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            aim_sound.Play();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            aim_sound.Play();
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            if (fps_cam.cam.fieldOfView > 45)
            {
                fps_cam.cam.fieldOfView = fps_cam.cam.fieldOfView - Time.deltaTime * cam_lerp;
            }            
        }
        else
        {
            if (fps_cam.cam.fieldOfView < 85)
            {
                fps_cam.cam.fieldOfView = fps_cam.cam.fieldOfView + Time.deltaTime * cam_lerp;
            }             
        }

        if (shotgun_bullets <= 1 || pistol_bullets <= 1)
        {
            bullets_alert.SetActive(true);
        }
        else
        {
            bullets_alert.SetActive(false);
        }


        if (shotgun.activeInHierarchy == true)
        {
            current_bullet_text.text = shotgun_bullets.ToString();
            all_bullet_text.text = all_bullets.ToString();

        }
        else if(pistol.activeInHierarchy == true)
        {
            current_bullet_text.text = pistol_bullets.ToString();
            all_bullet_text.text = all_bullets.ToString();
        }

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


        if (Input.GetKeyDown("1") && shotgun_animator.GetInteger("state")!= 2 && pistol_animator.GetInteger("state") != 2)
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
        if (Input.GetKeyDown("2") && shotgun_animator.GetInteger("state") != 2 && pistol_animator.GetInteger("state") != 2)
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
            shotgun_animator.speed = 2.2f;
            fire_rate_reset = 0.35f;         
            if (shotgun.activeInHierarchy == true && shotgun_animator.GetInteger("state") != 1 && shotgun_bullets >= 1)
            {
                shotgun_bullets = shotgun_bullets - 1;
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
            if (pistol.activeInHierarchy == true && pistol_animator.GetInteger("state") != 1 && pistol_bullets >=1)
            {
                pistol_bullets = pistol_bullets - 1;
                pistol_animator.speed = 3.0f;
                fire_rate_reset = 0.35f;
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

            if(pistol_bullets <=0 || shotgun_bullets <= 0)
            {
                if (pistol.activeInHierarchy == true)
                {
                    dry_fire.Play();
                }
                if (shotgun.activeInHierarchy == true)
                {
                    dry_fire.Play();
                }

            }

        }


        if (Input.GetKeyDown("r"))
        {
            if (shotgun.activeInHierarchy == true)
            {
                if(all_bullets >= shotgun_bullets)
                {
                    all_bullets = all_bullets - (8 - shotgun_bullets);
                    shotgun_bullets = 8;
                }
                else if (all_bullets < shotgun_bullets)
                {
                    shotgun_bullets = shotgun_bullets + all_bullets;
                    all_bullets = 0;
                }
                shotgun_animator.speed = 1.7f;
                shotgun_animator.SetInteger("state", 2);
            }

            if (pistol.activeInHierarchy == true)
            {
                if (all_bullets >= pistol_bullets)
                {
                    all_bullets = all_bullets - (15 - pistol_bullets);
                    pistol_bullets = 15;
                }
                else if (all_bullets < pistol_bullets)
                {
                    pistol_bullets = pistol_bullets + all_bullets;
                    all_bullets = 0;
                }
                pistol_animator.speed = 1.7f;
                pistol_animator.SetInteger("state", 2);
            }
            pistol_reload.Play();
            start_fire_rate = true;
        }
    }
}
