using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kill_enemies : MonoBehaviour
{
    public AudioSource spider_death_sound;
    public ricky_ai enemy_script;
    float timer_to_destroy = 4.5f;

    private void OnTriggerEnter(Collider other)
    {
        enemy_script = other.GetComponent<ricky_ai>();
        if (other.GetComponent<ricky_ai>() != null)
        {
            Debug.Log("we hit");
            enemy_script.ragdoll_death = false;
            enemy_script.gameObject.SetActive(true);
            enemy_script.enabled = true;
            enemy_script.ragdoll_death = true;
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
