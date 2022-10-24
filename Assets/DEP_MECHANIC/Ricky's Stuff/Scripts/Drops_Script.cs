using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drops_Script : MonoBehaviour
{

    public Ricky_Game_Script player_Script;

    //Bools
    public bool is_health = false;
    public bool is_ammo = false;
    public bool is_run = false;
    public bool is_firerate = false;

    //Models
    public GameObject health_object;
    public GameObject ammo_object;
    public GameObject run_object;
    public GameObject firerate_object;

    public AudioSource health_pickup_sound;
    public AudioSource ammo_pickup_sound;
    public AudioSource run_pickup_sound;
    public AudioSource firerate_pickup_sound;

    private void OnTriggerEnter(Collider other)
    {
        //Check If Is Player
        if(other.gameObject.layer == 6)
        {
            //Pass Refrence 
            player_Script = other.gameObject.GetComponent<Ricky_Game_Script>();

            //Collect
            if (player_Script != null)
            {
                if (is_health == true)
                {
                    health_pickup_sound.Play();
                    player_Script.health = player_Script.health + 10;
                    if(health_pickup_sound.isPlaying == false)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
                else if (ammo_object == true)
                {
                    ammo_pickup_sound.Play();
                    player_Script.ammo = player_Script.ammo + 10;
                    if (ammo_pickup_sound.isPlaying == false)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
                if (run_object == true)
                {
                    // run speed
                    run_pickup_sound.Play();
                    if (run_pickup_sound.isPlaying == false)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
                if (firerate_object == true)
                {
                    firerate_pickup_sound.Play();
                    // fire rate speed
                    if (firerate_pickup_sound.isPlaying == false)
                    {
                        this.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void Start()
    {
        //Activate Object Model
        if (is_health == true)
        {
            health_object.SetActive(true);
            ammo_object.SetActive(false);
            run_object.SetActive(false);
            firerate_object.SetActive(false);
        }
        if (is_ammo == true)
        {
            health_object.SetActive(false);
            ammo_object.SetActive(true);
            run_object.SetActive(false);
            firerate_object.SetActive(false);
        }
        if (is_run == true)
        {
            health_object.SetActive(false);
            ammo_object.SetActive(false);
            run_object.SetActive(true);
            firerate_object.SetActive(false);
        }
        if (is_firerate == true)
        {
            health_object.SetActive(false);
            ammo_object.SetActive(false);
            run_object.SetActive(false);
            firerate_object.SetActive(true);
        }
    }
}
