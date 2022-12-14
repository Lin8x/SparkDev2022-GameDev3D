using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_collider : MonoBehaviour
{
    float timer_to_destroy = 7;
    public float bullet_damage = 50;
    public GameObject explosion;
    bool already_instinciated = false;
    public AudioSource hit_enemies_sound;

    public GameObject particle_1;
    public GameObject particle_2;
    public GameObject particle_3;

    private void Start()
    {
        int ran_num = Random.Range(0, 3);
        if(ran_num == 0)
        {
            particle_1.SetActive(true);
            particle_2.SetActive(false);
            particle_3.SetActive(false);
        }
        if (ran_num == 1)
        {
            particle_1.SetActive(false);
            particle_2.SetActive(true);
            particle_3.SetActive(false);
        }
        if (ran_num == 2)
        {
            particle_1.SetActive(false);
            particle_2.SetActive(false);
            particle_3.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(already_instinciated == false && other.gameObject.layer == 7 || other.gameObject.layer == 9)
        {
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            already_instinciated = true;
        }  
      if(other.gameObject.layer == 7)
        {
            hit_enemies_sound.Play();
            enemy_spawner enemy_script = other.GetComponentInParent<enemy_spawner>();
            enemy_script.take_damage(bullet_damage);
            enemy_script.golem_animator.SetTrigger("Take Damage");
            //enemy_script.enemy_health = enemy_script.enemy_health - 30;
            Destroy(this.gameObject);
        }
    }

    private void Update()
    {
        timer_to_destroy = timer_to_destroy - Time.deltaTime;
        if (timer_to_destroy <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
