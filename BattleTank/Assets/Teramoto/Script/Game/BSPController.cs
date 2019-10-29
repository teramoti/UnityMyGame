using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSPController : MonoBehaviour
{
    private GameObject parent;

    void Update()
    {

        // 親オブジェクトを取得
        parent = transform.root.gameObject;

        // 親オブジェクトの位置と角度を取得
        Vector3 pos = parent.transform.position;
        Vector3 eul = parent.transform.eulerAngles;

        // 影の照射位置
        pos.y -= 10.0f;
        Vector3 posSha = pos;   // (0, y-10, 0)
        transform.position = posSha;

        // 傾いたら丸影が消えたようにみせる
        if (eul.x > 30 && eul.x < 330 || eul.z > 30 && eul.z < 330)
        {
            // 影の照射角度
            eul.x = 90.0f;
            Vector3 eulSha = eul;   // (90, 0, 0) 照射下向き、影なし。
            transform.eulerAngles = eulSha;
        }
        else
        {
            // 影の照射角度
            eul.x = 270.0f;
            Vector3 eulSha = eul;   // (270, 0, 0) 照射上向き、影あり。
            transform.eulerAngles = eulSha;
        }
    }
}