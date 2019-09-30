using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
//タイトルからMainに飛ぶ処理
public class TitleGoToMainGame : MonoBehaviour
{
    public GameObject effectPrefab;

    int timer;
    bool IsSceneFlag;

    bool IsPress;

    //移動音
    public AudioClip sound;

    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        IsSceneFlag = false;
        IsPress = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            IsPress = true;
            // 効果音を出す。
            AudioSource.PlayClipAtPoint(sound, transform.position);
        }


        if(IsPress==true)
        {
            timer++;

        }
        if (timer < 180 && IsPress==true)
        {
            //光るエフェクト
            GameObject effect = Instantiate(effectPrefab, new Vector3(transform.position.x-50, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(effect, 2.0f);

            //光るエフェクト
            GameObject effect2 = Instantiate(effectPrefab, new Vector3(transform.position.x + 50, transform.position.y, transform.position.z), Quaternion.identity);
            Destroy(effect2, 2.0f);

        }
        if (timer > 180)
        {
            IsSceneFlag = true;
        }

        if (IsSceneFlag==true)
        {
            SceneManager.LoadScene("Main");
        }

    }

    public bool GetPushFlag()
    {
        return IsPress;
    }
}
