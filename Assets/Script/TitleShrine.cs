using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleShrine : MonoBehaviour
{
        Rigidbody rigidbody;
         private Transform _transform;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        _transform = transform;
    }

    // Update is called once per frame
    float speed = 2.15f;
    void Update()
    {
        this.rigidbody.velocity = transform.forward * speed;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "warp")
        {
            // transform?????
            Transform myTransform = this.transform;
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0f; 
            worldAngle.y = 180f; 
            worldAngle.z = 0f;
            Vector3 pos = myTransform.position;
            pos.x = 0;
            pos.y = 1;
            pos.z = 41;
            myTransform.position = pos;  // ç¿ïWÇê›íË
        }
    }
}
