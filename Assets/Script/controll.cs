using System.Linq;
using System.Runtime.CompilerServices;
using System.Dynamic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.IO;
using System.Timers;
using System.Threading.Tasks;
using UnityEngine.UI;
public class controll : MonoBehaviour
{
    public shrin shrinscript;
    public SystemScript systemscript;
    public GameObject right;
    public GameObject left;
    public GameObject pointer;
    public GameObject Speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int point = 0;
        int bpmr = 0;
        int bpml = 0;
        float speed = 0;
        bpmr = shrinscript.GetBpmr();
        bpml = shrinscript.GetBpml();
        speed = shrinscript.GetSpeed() * 100;
        point = shrinscript.GetPoint() + systemscript.GetPointScore();
        pointer.GetComponent<Text>().text = "point : " + point.ToString("000");
        pointer.GetComponent<Text>().enabled = true;
        right.GetComponent<Text>().text = "right : " + bpmr.ToString("000");
        right.GetComponent<Text>().enabled = true;
        left.GetComponent<Text>().text = "left : " + bpml.ToString("000");
        left.GetComponent<Text>().enabled = true;
        Speed.GetComponent<Text>().text = "speed : " + speed.ToString("000");
        Speed.GetComponent<Text>().enabled = true;
    }
}
