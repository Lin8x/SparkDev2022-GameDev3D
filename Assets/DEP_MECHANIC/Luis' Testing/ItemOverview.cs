using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOverview : MonoBehaviour
{

    public GameObject billboardToCreate;
    GameObject cloneBillboard;
    [SerializeField] private float height = 1f;

    void OnTriggerEnter(Collider triggerCollider)
    {
        if (triggerCollider.gameObject.layer == 6){
            cloneBillboard = Instantiate(billboardToCreate, new Vector3(this.transform.position.x, this.transform.position.y + height, this.transform.position.z), Quaternion.identity);
            cloneBillboard.transform.parent = this.transform;
        }
    }

    void OnTriggerExit(Collider triggerCollider)
    {
        Destroy(cloneBillboard);
    }

}