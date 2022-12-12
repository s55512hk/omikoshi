using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject button;
     public SystemScript sys;
    void Start()
    {
        button.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ClickStartButton()
    {
        SceneManager.LoadSceneAsync("TitleScene");
    }
}
