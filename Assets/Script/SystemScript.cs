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
public class SystemScript : MonoBehaviour
{
    public GameObject chara;
    public GameObject gameclea;
    public GameObject button;
    public GameObject right;
    public GameObject left;
    public GameObject speed;
    public shrin shrinscript;

    int timeScore = 0;
    private void OnTriggerEnter(Collider other)
    {
        //もしゴールオブジェクトのコライダーに接触した時の処理。
        if (other.name == chara.name)
        {
            //ゲームクリアテキストを表示させてキャラクターを非表示にします。
            button.SetActive(true);
            right.SetActive(false);
            left.SetActive(false);
            speed.SetActive(false);
            gameclea.GetComponent<Text>().text = "CLEAR";
            gameclea.GetComponent<Text>().enabled = true;
            Debug.Log("clear");
            chara.GetComponent<shrin>().enabled = false;
            chara.SetActive (false);
            StartCoroutine(APIExample());
            //時間処理
            DateTime startTime = shrinscript.GetStartTime();
            DateTime endTime = DateTime.Now;
            timeScore = (endTime.Second - startTime.Second) + 60 * (endTime.Minute - startTime.Minute) + 3600 * (endTime.Hour - startTime.Hour);
            timeScore = 120 - timeScore;
            if(timeScore <= 0){
                timeScore = 0;
            }else{
                timeScore *= 20;
            }
        }
    }
    public int GetPointScore(){
        return timeScore;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     public class PostData
    {
        public float a;
        public float b;
        public float c;
        public float bpm_speed;
        public int bpm_right;
        public int bpm_left;
    }
    IEnumerator APIExample()
    {
        string requestURLpos = "https://omikoshi.azurewebsites.net/position.php";
        string url = requestURLpos;
        // JSONのデータをBodyに入れてPOSTする
        PostData postData = new PostData();
        postData.a = 4.66f;
        postData.b = 0.2f;
        postData.c = 0;
        postData.bpm_speed =0;
        postData.bpm_right =0;
        postData.bpm_left = 0;
        string myJson = JsonUtility.ToJson(postData);
        byte[] byteData = System.Text.Encoding.UTF8.GetBytes(myJson);
        using UnityWebRequest request = new UnityWebRequest(url, "POST");
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(byteData);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();


    }
}
