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

    private int  MAXSTAGENUM= 10;

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

    public Text round;

    int textnum;

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
        round.text = "" + textnum;

    }
    void Update()
    {

        StageWait();
         // Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
         enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        textnum=stagenum + 1;
        enemyNum = enemyObjects.Length;
        round.text = "" + textnum;

        // データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
        if (enemyNum == 0)
        {
            //ここで全滅したときの音を鳴らす
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(clearSound);

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
                foreach (GameObject obj in enemyObjects)
                {
                    obj.gameObject.SetActive(false);
                    print("消す");
                }

            }
            else
            {
                cleartimer++;
                Destroy();
                winUI.enabled = true;

            }
        }

        if(cleartimer> 120)
        {

            print("リザルトをよびます");
            SceneManager.LoadScene("GameClear");


        }
    }


    void LoadStage()
    {
        stagenum += 1;
        brockObjects = GameObject.FindGameObjectsWithTag("Brock");

        foreach (GameObject obj in brockObjects)
        {
            Destroy(obj);
        }
        script.Make(stagenum);

        print("現在のステージは"+stagenum);

        animeFlag = true;

        clearFlag = false;
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
            foreach (GameObject obj in enemyObjects)
            {
                obj.gameObject.SetActive(true);
            }


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
