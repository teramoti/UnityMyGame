using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    public GameObject effectPrefab1;
    public GameObject effectPrefab2;
    public int tankHP=5;
    [SerializeField]
    private int maxHP=10;
    public Text HPLabel;

    void Start()
    {
        HPLabel.text = "×" + tankHP;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyShell")
        {
            tankHP -= 1;
            HPLabel.text = "×" + tankHP;
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
               // GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
              //  Destroy(effect1, 1.0f);
            }
            else
            {
               // GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
               // Destroy(effect2, 1.0f);
                this.gameObject.SetActive(false);
                Invoke("GoToGameOver", 1.5f);
            }
        }
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