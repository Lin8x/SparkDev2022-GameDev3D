using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_enemies : MonoBehaviour
{
    public AudioSource spider_death_sound;
    float timer_to_destroy = 4.5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<enemy_ai>() != null)
        {
            float num = Random.Range(0.1f, 0.5f);
            spider_death_sound.pitch = spider_death_sound.pitch + num;
            spider_death_sound.Play();
            Debug.Log(other.gameObject);
            Destroy(other.gameObject);
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
