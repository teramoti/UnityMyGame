
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// オブジェクトを点滅させるクラス
public class Blinker : MonoBehaviour
{


    public Image image;
     int timer;
    [SerializeField]
    private int flashtime=10;

    GameObject obj;
    TitleGoToMainGame script;

    void Start()
    {
        timer = 0;

        obj = GameObject.Find("TitleManager");
        script = obj.GetComponent<TitleGoToMainGame>();

    }
    void Update()
    {
        timer++;
        if (script.GetPushFlag() == false)
        {
            if (timer % flashtime == 0)
            {
                image.enabled = !image.enabled;

            }

            if(timer>6000)
            {
               timer = 0;
            }
        }
        else
        {
            image.enabled = true;

        }

    }
}