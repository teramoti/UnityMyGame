﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friezeTrap : MonoBehaviour
{ 

    private TankMovement TM;
    public AudioClip trapSound;
    public GameObject effectPrefab;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
    
            // Trapを画面から消す。
            // DestroyメソッドだとInvokeメソッドを使えない（ポイント）。
            this.gameObject.SetActive(false);
    
            // 効果音を出す。
            //AudioSource.PlayClipAtPoint(trapSound, transform.position);
    
            // エフェクトを出す。（posでエフェクトの出現位置を調整する。）
            Vector3 pos = other.transform.position;
            //GameObject effect = (GameObject)Instantiate(effectPrefab, new Vector3(pos.x, pos.y + 1, pos.z - 1), Quaternion.identity);
    
            // エフェクトを２秒後に消す。
            //Destroy(effect, 2.0f);
    
            // プレーヤーの動きを止める。
            TM = other.GetComponent<TankMovement>();
            TM.enabled = false;
    
            // 2秒後にReleaseメソッドを呼び出す。
            Invoke("Release", 2.0f);
        }
    }
    
    void Release()
    {
        TM.enabled = true;
    }
}