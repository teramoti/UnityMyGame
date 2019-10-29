using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    //ダメージエフェクト
    public GameObject effectPrefab1;
    //爆破エフェクト
    public GameObject effectPrefab2;

    public int tankHP = 5;

    [SerializeField]
    private int maxHP = 5;

    public Text HPLabel;


    //移動音
    public AudioClip damegeSound;

    private AudioSource audioSource;

    void Start()
    {
        HPLabel.text = "×" + tankHP;
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (tankHP <=  0)
        {
            tankHP = 0;

            //爆破エフェクト
            GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
            Destroy(effect2,2.0f);
            this.gameObject.SetActive(false);
            //イベントを呼ぶ
            Invoke("GoToGameOver", 1.5f);
        }
    }


    public void Damage(Collider other)
    {

        tankHP -= 1;

        Destroy(other);
        //音(sound1)を鳴らす
        audioSource.PlayOneShot(damegeSound);
        //ダメージエフェクト

        GameObject effect = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
        Destroy(effect, 2.0f);


        if (tankHP <= 0)
        {
            tankHP = 0;
        }


        HPLabel.text = "×" + tankHP;




    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // ★追加
    // publicをつけること（重要ポイント）
    public void AddHP(int amount)
    {
        
        tankHP += amount;
        Debug.Log(amount);
        // ここは何をコントロールしている考えてみましょう！
        if (tankHP > maxHP)
        {
            tankHP = maxHP;
        }

        HPLabel.text = "×" + tankHP;
    }
}