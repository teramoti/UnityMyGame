using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    public int shotCount;
    public Text shellLabel;
    private float timeBetweenShot = 0.35f;
    private float timer;
    [SerializeField]
    private float deleteBullet = 5.0f;
    void Start()
    {
       // shellLabel.text = "×" + shotCount;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBetweenShot)
        {
            //if (shotCount < 1)
            //{
            //    return;
            //}

            //shotCount -= 1;
            //shellLabel.text = "×" + shotCount;
            timer = 0.0f;
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            shell.transform.rotation = this.transform.rotation;
            Destroy(shell, deleteBullet);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // ★追加
    // 残弾数を増加させるメソッド（関数・命令ブロック）
    // 外部からこのメソッドを呼び出せるように「public」をつける（重要ポイント）
    // この「AddShellメソッド」を「ShellItem」スクリプトから呼び出す。
    //public void AddShell(int amount)
    //{
    //    // shotCountをamount分だけ回復させる
    //    shotCount += amount;

    //    // ただし、残弾数が最大値を超えないようする。(最大値は自由に設定)
    //    if (shotCount > 30)
    //    {
    //        shotCount = 30;
    //    }

    //    // 回復をUIに反映させる。
    //    shellLabel.text = "×" + shotCount;
    //}
}