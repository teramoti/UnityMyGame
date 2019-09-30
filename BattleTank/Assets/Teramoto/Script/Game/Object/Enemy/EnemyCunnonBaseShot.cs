

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCunnonBaseShot : MonoBehaviour
{
    //弾のPrefab
    public GameObject enemyShellPrefab;
    //発射速度
    public float shotSpeed;
    //撃つときの音
    public AudioClip shotSound;
    //リロード時間
    private int shotIntarval;


    private AudioSource audioSource;


    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }
    void Update()
    {
        shotIntarval += 1;

        if (shotIntarval % 60 == 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            audioSource.PlayOneShot(shotSound);

            Destroy(enemyShell, 3.0f);
        }
    }
}