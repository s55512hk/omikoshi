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
using System.Text;


public class shrin : MonoBehaviour
{
    int point = 0;
    bool eventflag = false;
    int kamera = 0;
    bool delay = false;
    bool Event = false;
    bool Goal = false;
    int bpmr, bpml;
    int iSecond = 0;
    float speed = 0;
    string persong;
    int minute = 0;
    int second = 0;
    int Hour = 0;
    int number = 0;
    float x, y, z = 0;

    public GameObject EventCube;
    public int GetPoint()
    {
        return point;
    }
    public int GetKamera()
    {
        return kamera;
    }
    public float GetSpeed()
    {
        return speed;
    }
    public int GetBpmr()
    {
        return bpmr;
    }
    public int GetBpml()
    {
        return bpml;
    }
    public DateTime GetStartTime()
    {
        return startTime;
    }
    [SerializeField] Text text;
    private IEnumerator DelayMethod(float waitTime)
    {
        text.GetComponent<Text>().text = "ê¨å˜!Ç±ÇÃâ∆Ç…çKâ^Ç™ç~ÇËíçÇ¢Çæ";
        text.enabled = true;
        yield return new WaitForSeconds(waitTime);
        EventCube.SetActive(false);
        Event = false;
        text.enabled = false;
        kamera = 0;
    }
    private IEnumerator DelayMethod2(float waitTime)
    {
        text.GetComponent<Text>().text = "ìπòHÇ©ÇÁÇÕÇ›èoÇ‹ÇµÇΩ";
        text.enabled = true;
        yield return new WaitForSeconds(waitTime);
        delay = false;
        text.enabled = false;
    }
    private Transform _transform;

    // Start is called before the first frame update
    Rigidbody rigidbody;
    string requestURL = "https://omikoshi.azurewebsites.net/sample.js";
    string requestURLpos = "https://omikoshi.azurewebsites.net/position.php";
    string requestURLposjs = "https://omikoshi.azurewebsites.net/position.js";
    // Queue bpmr = new Queue();
    // Queue bpml = new Queue();
    DateTime startTime;
    void Start()
    {
        // StartCoroutine(GetPos());
        rigidbody = this.GetComponent<Rigidbody>();
        DateTime dtNow = DateTime.Now;
        startTime = dtNow;
        iSecond = dtNow.Second;
        _transform = transform;
        text.enabled = false;
        //?L???[??????
        // for (int i = 0; i < 2; i++)
        // {
        //     bpmr.Enqueue(0);
        //     bpml.Enqueue(0);
        // }
    }

    // Update is called once per frame

    //?T?[?o?[???èÔ???
    // IEnumerator GetPos()
    // {
    //     UnityWebRequest www = UnityWebRequest.Get(requestURLposjs);
    //     yield return www.SendWebRequest();
    //     if (www.isNetworkError || www.isHttpError)
    //     {
    //         Debug.Log(www.error);
    //     }
    //     else
    //     {
    //         string StartPosition;
    //         string pospos;
    //         StartPosition = www.downloadHandler.text;
    //         //x
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         x = float.Parse(pospos);
    //         Debug.Log("x = " + x);
    //         //y
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         y = float.Parse(pospos);
    //         Debug.Log("y = " + y);
    //         //z
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         z = float.Parse(pospos);
    //         Debug.Log("z = " + z);
    //         //speed
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         speed = float.Parse(pospos);
    //         Debug.Log("speed = " + speed);
    //         //bpmr
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         bpmr = Int32.Parse(pospos);
    //         Debug.Log("bpmr = " + bpmr);
    //         //bpml
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf(","));
    //         bpml = Int32.Parse(pospos);
    //         Debug.Log("bpml = " + bpml);
    //         //number
    //         pospos = StartPosition.Remove(0, StartPosition.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Remove(0, pospos.IndexOf(":"));
    //         pospos = pospos.Remove(0, 1);
    //         pospos = pospos.Substring(0, pospos.IndexOf("}"));
    //         number = Int32.Parse(pospos);
    //         Debug.Log("number = " + number);

    //         Transform myTransform = this.transform;
    //         Vector3 pos = myTransform.position;
    //         pos.x = x;
    //         pos.y = y;
    //         pos.z = z;
    //         myTransform.position = pos;

    //     }
    // }
    IEnumerator GetText()
    {
        DateTime dtNow = DateTime.Now;
        TimeSpan tsNow = new TimeSpan(0, 0, 0, 1);
        DateTime twoSecondBefore = dtNow - tsNow;
        int nowSecond = twoSecondBefore.Second;
        int nowMinute = twoSecondBefore.Minute;
        int nowHour = twoSecondBefore.Hour;
        UnityWebRequest www = UnityWebRequest.Get(requestURL);
        yield return www.SendWebRequest();
        string chat;
        string chatO;
        string chatV;
        int n1 = 3, n2 = 7, n3 = 11;

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            chat = www.downloadHandler.text;
                chatO = chat;
            for (; (nowHour >= Hour && nowMinute >= minute && nowSecond >= second) || nowSecond <= 1; number++)
            {
                 //Hour?èÔ
                if (chat == "")
                {
                    number = 0;
                    break;
                }
                chatV = chat.Remove(0, chat.IndexOf("\""));
                for (int i = 0; i < n2 + 12 * number; i++)
                {
                    chatV = chatV.Remove(0, chatV.IndexOf("\""));
                    chatV = chatV.Remove(0, 1);
                }
                chatV = chatV.Remove(2, 8);
                chatV = chatV.Remove(chatV.IndexOf("\""));
                Hour = Int32.Parse(chatV);

                //minute???
                chat = chatO;
                chatV = chat.Remove(0, chat.IndexOf("\""));
                for (int i = 0; i < n2 + 12 * number; i++)
                {
                    chatV = chatV.Remove(0, chatV.IndexOf("\""));
                    chatV = chatV.Remove(0, 1);
                }
                chatV = chatV.Remove(0, chatV.IndexOf(":"));
                chatV = chatV.Remove(0, 1);
                chatV = chatV.Remove(2, 5);
                chatV = chatV.Remove(chatV.IndexOf("\""));
                minute = Int32.Parse(chatV);

                //Get second
                chatV = chat.Remove(0, chat.IndexOf("\""));
                for (int i = 0; i < n2 + 12 * number; i++)
                {
                    chatV = chatV.Remove(0, chatV.IndexOf("\""));
                    chatV = chatV.Remove(0, 1);
                }
                chatV = chatV.Remove(0, chatV.IndexOf(":"));
                chatV = chatV.Remove(0, 1);
                chatV = chatV.Remove(0, chatV.IndexOf(":"));
                chatV = chatV.Remove(0, 1);
                chatV = chatV.Remove(chatV.IndexOf("\""));
                second = int.Parse(chatV);
                //Debug.Log("second : " + chatV + " ");
            }
            for (int j = 0; j < number; j++)
            {
                //get person
                chatV = chatO.Remove(0, chat.IndexOf("\""));
                for (int i = 0; i < n1 + 12 * j; i++)
                {
                    chatV = chatV.Remove(0, chatV.IndexOf("\""));
                    chatV = chatV.Remove(0, 1);
                }
                chatV = chatV.Remove(chatV.IndexOf("\""));
                persong = chatV;

                //get bpm
                chat = chatO;
                chatV = chat.Remove(0, chat.IndexOf("\""));
                for (int i = 0; i < n3 + 12 * j; i++)
                {
                    chatV = chatV.Remove(0, chatV.IndexOf("\""));
                    chatV = chatV.Remove(0, 1);
                }
                chatV = chatV.Remove(chatV.IndexOf("\""));
                if (persong == "Right")
                {
                    // bpmr.Enqueue(int.Parse(chatV));
                    // bpmr.Dequeue();
                    bpmr = (int.Parse(chatV));
                }
                else if (persong == "Left")
                {
                    // bpml.Enqueue(int.Parse(chatV));
                    // bpml.Dequeue();
                    bpml = (int.Parse(chatV));
                }
            }
        }
        Debug.Log(number);
    }
    int nextsecond = 0;
    int nextmilli = 0;
    int iSmilli = 0;
    float timer = 0;
    void Update()
    {
        DateTime dtNow = DateTime.Now;
        nextsecond = dtNow.Second;
        //2?b?O(?????p?f?[?^)???
        if (timer > 0.2f)
        {
            //StartCoroutine(APIExample());
            StartCoroutine(GetText());
            timer = 0;
        }
        else
            timer += Time.deltaTime;
        if (delay == false && Event == false)
        {
            if (bpml > bpmr + 15)
            {
                this.transform.Rotate(new Vector3(0f, 0.04f, 0f));
            }
            if (bpml + 15 < bpmr)
            {
                this.transform.Rotate(new Vector3(0f, -0.04f, 0f));
            }
            speed = ((float)bpmr + (float)bpml) / 80;
        }
        else if (Event == true)
        {
            text.GetComponent<Text>().text = "110à»è„ÇÃÉäÉYÉÄÇóºï˚èoÇµÇƒ!!";
            text.enabled = true;
            speed = (float)0;
            this.transform.Rotate(new Vector3(0f, 0f, 0f));
            if (bpmr >= 110 && bpml >= 110)
            {
                if (eventflag == true)
                {
                    point += 110;
                    eventflag = false;
                }
                Coroutine coroutine = StartCoroutine("DelayMethod", 2.0f);
            }
        }
        else if (delay == true)
        {
            speed = (float)0;
            Transform myTransform = this.transform;
            Coroutine coroutine = StartCoroutine("DelayMethod2", 2.0f);
        }
        this.rigidbody.velocity = transform.forward * speed;
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            // transform?????
            Transform myTransform = this.transform;
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0f;
            worldAngle.y = 0f;
            worldAngle.z = 0f;
            myTransform.eulerAngles = worldAngle; // âÒì]äpìxÇê›íË
            bpmr = 0;
            bpml = 0;
            // ???W?????
            Vector3 pos = myTransform.position;
            pos.x = -0.3f;
            pos.y = -0.2f;
            myTransform.position = pos;  // ç¿ïWÇê›íË
            delay = true;
            point -= 10;

        }
        if (collision.gameObject.tag == "Event")
        {
            // transform?????
            Transform myTransform = this.transform;
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0f;
            worldAngle.y = 0f;
            worldAngle.z = 0f;
            myTransform.eulerAngles = worldAngle; // âÒì]äpìxÇê›íË
            Vector3 pos = myTransform.position;
            pos.x = -0.3f;
            pos.y = -0.2f;
            pos.z = pos.z - 0.2f;
            myTransform.position = pos;  // ç¿ïWÇê›íË
            bpmr = 0;
            bpml = 0;
            Event = true;
            eventflag = true;
            kamera = 1;

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Goal")
        {
            // transform?????
            Transform myTransform = this.transform;
            Vector3 worldAngle = myTransform.eulerAngles;
            worldAngle.x = 0f; 
            worldAngle.y = 0f; 
            worldAngle.z = 0f;
            Vector3 pos = myTransform.position;
            pos.x = 0;
            pos.y = 0.5f;
            pos.z = 0;
            myTransform.position = pos;  // ç¿ïWÇê›íË
        }
    }
    // public class PostData
    // {
    //     public float a;
    //     public float b;
    //     public float c;
    //     public float bpm_speed;
    //     public int bpm_right;
    //     public int bpm_left;
    //     public int bpm_num;
    // }
    // IEnumerator APIExample()
    // {

    //     string url = requestURLpos;
    //     // JSONÇÃÉfÅ[É^ÇBodyÇ…ì¸ÇÍÇƒPOSTÇ∑ÇÈ
    //     PostData postData = new PostData();
    //     postData.a = this.transform.position.x;
    //     postData.b = this.transform.position.y;
    //     postData.c = this.transform.position.z;
    //     postData.bpm_speed = speed;
    //     postData.bpm_right = bpmr;
    //     postData.bpm_left = bpml;
    //     postData.bpm_num = number;
    //     string myJson = JsonUtility.ToJson(postData);
    //     byte[] byteData = System.Text.Encoding.UTF8.GetBytes(myJson);
    //     using UnityWebRequest request = new UnityWebRequest(url, "POST");
    //     request.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteData);
    //     request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
    //     request.SetRequestHeader("Content-Type", "application/json");
    //     yield return request.SendWebRequest();


    // }
}
