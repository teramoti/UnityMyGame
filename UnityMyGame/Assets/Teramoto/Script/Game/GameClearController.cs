using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearController : MonoBehaviour {
    // 配列（同じ種類の複数のデータを収納するための箱を作る）
    private GameObject[] enemyObjects;

    private int stagenum;

    private int MAX_STAGE_NUM = 2;

    private float loadTime;
    void Update()
    {

        // Enemyというタグが付いているオブジェクトのデータを箱の中に入れる。
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // データの入った箱の数をコンソール画面に表示する。
        print("敵の数"+enemyObjects.Length);

        // データの入った箱のデータが０に等しくなった時（Enemyというタグが付いているオブジェクトが全滅したとき）
        if (enemyObjects.Length == 0)
        {

            // ゲームクリアーシーンに遷移する。
            loadTime = Time.time;
            //一定時間たったらステージを作る

            Debug.Log(loadTime);

            //経過時間過ぎたらLoadStageを呼ぶ
            if(loadTime>= 0.01f)
            {
                Debug.Log("現在のステージは" + stagenum);
                LoadStage(stagenum);
                stagenum += 1;
                loadTime = 0;
            }


            Debug.Log("次のステージは"+stagenum);


            if (stagenum>MAX_STAGE_NUM)
            {
                stagenum = MAX_STAGE_NUM;
                Debug.Log("Clear");
                //もしステージくりあなら
                //SceneManager.LoadScene("GameClear");
            }
        }
    }

    void LoadStage(int stageNum)
    {   
        //CSVデータを読む



    }
}
