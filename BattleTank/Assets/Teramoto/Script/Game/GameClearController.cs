using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

using UnityEngine.UI;


public class GameClearController : MonoBehaviour
{
    // 配列（同じ種類の複数のデータを収納するための箱を作る）
    private GameObject[] enemyObjects;
    private GameObject[] enemyBullets;
    private GameObject[] playerBullets;
    private GameObject[] brockObjects;
    private GameObject[] hpBox;

    private int stagenum;

    private int  MAXSTAGENUM= 8;

    private float loadTime;

    GameObject csv;
    CreateMap script;

    //クリア音
    public AudioClip clearSound;

    private AudioSource audioSource;

    int enemyNum;

    bool clearFlag = false;

    bool animeFlag;

    int timer;
    
    //全部クリアしたときの作動時間
    int cleartimer;

    public Image winUI;

    public Image startUI;

    public Sprite[] numimage;

    public List<int> number = new List<int>();

    public Image round;

    int textnum;

    //音が鳴ったかのFlag
    bool ISSound;

    //音がすでに鳴ったかのFlag
    bool IsPlaySound;

    void Start()
    {
        csv = GameObject.Find("csv");
        script = csv.GetComponent<CreateMap>();
        stagenum = 0;

        clearFlag = false;

        audioSource = GetComponent<AudioSource>();

        loadTime = 0.0f;

        animeFlag = false;
        timer = 0;
        cleartimer = 0;  
        winUI.enabled = false;
        startUI.enabled = false;
        textnum = stagenum + 1;
        //round.text = "" + textnum;
        ISSound = false;

    }
    void Update()
    {

        StageWait();
         // Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
         enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        textnum=stagenum + 1;
        enemyNum = enemyObjects.Length;
      //  round.text = "" + textnum;
        View(textnum);
        // データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
        if (enemyNum == 0)
        {

            //音はなっていない
            if(!ISSound)
            {
                //音を鳴らす。
                audioSource.PlayOneShot(clearSound);
                ISSound = true;
            }

            clearFlag = true;



            // ゲームクリアーシーンに遷移する。
            loadTime = Time.time;


            //Debug.Log("倒した後"+loadTime);


        //    Debug.Log("今のステージは" + stagenum);
        }




        if (clearFlag == true)
        {
            if (stagenum < MAXSTAGENUM)
            {
                //マップ読み込み
                LoadStage();

            }
            else
            {
                if(!IsPlaySound)
                {
                    IsPlaySound = true;
                       ISSound = true;
                }

                cleartimer++;
                Destroy();
                winUI.enabled = true;

            }
        }

        //clear用timerが2秒こえたら
        if(cleartimer> 120)
        {
            //Sceneをいどうさせる
            SceneManager.LoadScene("GameClear");
        }
    }


    void LoadStage()
    {
        stagenum += 1;

        script.Make(stagenum);

        print("現在のステージは"+stagenum);

        animeFlag = true;

        clearFlag = false;
    }
    void View(int score)
    {
        var digit = score;
        //要素数0には１桁目の値が格納
        List<int> number = new List<int>();
        while (digit != 0)
        {
            score = digit % 10;
            digit = digit / 10;
            number.Add(score);
        }

        GameObject.Find("ScoreImage").GetComponent<Image>().sprite = numimage[number[0]];
        for (int i = 1; i < number.Count; i++)
        {
            //複製
            RectTransform scoreimage = (RectTransform)Instantiate(GameObject.Find("ScoreImage")).transform;
            scoreimage.SetParent(this.transform, false);
            scoreimage.localPosition = new Vector2(
                scoreimage.localPosition.x - scoreimage.sizeDelta.x * i,
                scoreimage.localPosition.y);
            scoreimage.GetComponent<Image>().sprite = numimage[number[i]];
        }
    }
    public bool GetAnimeFlag()
    {
        return animeFlag;
    }

    void StageWait()
    {
        if (animeFlag == true)
        {
            timer++;
            winUI.enabled = true;

            Destroy();

            ISSound = false;

        }
        if(timer>90)
        {
            winUI.enabled = false;
            startUI.enabled = true;

        }
        if (timer > 180)
        {
            animeFlag = false;
            timer = 0;
            startUI.enabled = false;
        }

    }

    void Destroy()
    {
        playerBullets = GameObject.FindGameObjectsWithTag("Shell");
        enemyBullets = GameObject.FindGameObjectsWithTag("EnemyShell");
        hpBox= GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject obj in enemyBullets)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in playerBullets)
        {
            Destroy(obj);
        }
        foreach (GameObject obj in hpBox)
        {
            Destroy(obj);
        }


        
    }

}
