using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public GameObject shellPrefab;
    public float shotSpeed;
    public int shotCount;

    //打った時の音
    public AudioClip shotSound;

    private AudioSource audioSource;


    [SerializeField]
    private float timeBetweenShot = 0.5f;
    private float timer;
    [SerializeField]
    private float deleteBullet = 5.0f;
    void Start()
    {

        //Componentを取得
        audioSource = GetComponent<AudioSource>();

    }

    void Update()
    {
        timer += Time.deltaTime;
        /*射撃ボタン1が押されたとき*/
        bool fire = Input.GetButtonDown("Fire2");
        if (fire==true && timer > timeBetweenShot)
        {
            //音(sound1)を鳴らす
            audioSource.PlayOneShot(shotSound,2.0f);
            timer = 0.0f;
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            shell.transform.rotation = this.transform.rotation;
            Destroy(shell, deleteBullet);
        }
    }
}