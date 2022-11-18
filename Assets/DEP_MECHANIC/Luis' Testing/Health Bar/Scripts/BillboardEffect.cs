using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    private UnityEngine.Camera thisCamera;
    public bool useStaticBillboard;

    // Start is called before the first frame update
    void Start()
    {
        thisCamera = UnityEngine.Camera.main;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!useStaticBillboard)
            transform.LookAt(thisCamera.transform);
        else
            transform.rotation = thisCamera.transform.rotation;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }
}
