using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultBullet : MonoBehaviour
{
    public GameObject shellPrefab;
    public float shotSpeed;
    public AudioClip shotSound;
    public int shotCount;
    private float timeBetweenShot = 0.5f;
    private float timer;
    [SerializeField]
    private float deleteBullet = 5.0f;
    void Start()
    {
    }

    void Update()
    {
        timer += Time.deltaTime;

        if ( timer > timeBetweenShot)
        {
            timer = 0.0f;
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();
            shellRb.AddForce(transform.forward * shotSpeed);
            shell.transform.rotation = this.transform.rotation;
            Destroy(shell, deleteBullet);
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

}
