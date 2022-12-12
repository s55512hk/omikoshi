using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControll : MonoBehaviour
{
    Rigidbody rigidbody;
    private Transform _transform;
    public shrin shrinscript;
    public Transform target;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        int camera = shrinscript.GetKamera();
        if(camera == 1){
            Transform myTransform = this.transform;
            Vector3 pos = myTransform.position;
            pos.x = -5f;
            pos.y = 3f;
            pos.z = 52f;
            myTransform.position = pos; 
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0f; 
            worldAngle.y = 90f; 
            worldAngle.z = 0f;
            myTransform.eulerAngles = worldAngle;
        }else{
        Transform myTransformG = this.transform;
            offset = new Vector3(0, 4, -6); 
            Vector3 worldAngleG = myTransformG.eulerAngles;
             worldAngleG.x = 15f; 
            worldAngleG.y = 0f; 
            myTransformG.eulerAngles = worldAngleG;
            this.transform.position = target.position + offset;
        }
    }
}
