using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion_script : MonoBehaviour
{
    public GameObject explosion;
    public Ricky_Game_Script rickys_script;

    private void OnCollisionEnter(Collision collision)
    {
        if (rickys_script != null)
        {
        //Pass how far explision happened
        rickys_script.explosion_distance(Vector3.Distance(this.transform.position, rickys_script.gameObject.transform.position));          
        }

        //Create Explosion Particle
        Instantiate(explosion, this.transform.position, this.transform.rotation);

        //Destroy This
        Destroy(this.gameObject);
    }
}
