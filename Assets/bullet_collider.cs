using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet_collider : MonoBehaviour
{
    float timer_to_destroy = 7;
    public float bullet_damage = 50;

    private void OnTriggerEnter(Collider other)
    {
      if(other.gameObject.layer == 7)
        {
            enemy_spawner enemy_script = other.GetComponentInParent<enemy_spawner>();
            enemy_script.take_damage(bullet_damage);
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
