using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public GameObject effectPrefab;

    public GameObject breakObjecteffectPrefab;
    public int objectHP;


    //移動音
    public AudioClip damegeSound;

    private AudioSource audioSource;

    GameObject score;

    [SerializeField]
    private int enemySocre=0; 
    Score script;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Shell"))
        {
            // ★★追加
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // ★★追加
            // もしもHPが0よりも大きい場合には（条件）
            if (objectHP > 0)
            {
                Destroy(other.gameObject);
                GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 2.0f);
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(damegeSound);
                audioSource.volume = 3.0f;
            }
            else
            {
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(damegeSound);
                audioSource.volume = 3.0f;

                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = Instantiate(breakObjecteffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);


                score = GameObject.Find("Canvas");
                script = score.GetComponent<Score>();
                script.AddScore(enemySocre);
                Destroy(this.gameObject);
            }
        }
    }
}