using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
  
    void Update()
    {
        //Debug.Log("test");
        transform.position = target.position;
    }
}
