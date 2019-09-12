﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomController : MonoBehaviour
{
    private Camera cam;
    private float zoom;
    private float view;

    void Start()
    {
        cam = GetComponent<Camera>();
        view = cam.fieldOfView;
    }

    void Update()
    {
        cam.fieldOfView = view + zoom;

        // 最小値と最大値を決める（自由に変更可能）
        if (cam.fieldOfView < 10f)
        {
            cam.fieldOfView = 10f;
        }

        // 「自分の主観カメラ」を基準に数値を決めてください。
        if (cam.fieldOfView > 60f)
        {
            cam.fieldOfView = 60f;
        }

        // 左SHIFTを押すと、zoomの数値が減少（ボタンは自由に変更可能）
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // どれくらいの速度でzoomを変更させるかも自由です。
            zoom -= 0.3f;

        } // 右SHIFTを押すと、zoomの数値が増加（ボタンは自由に変更可能）
        else if (Input.GetKey(KeyCode.RightShift))
        {
            zoom += 0.3f;
        }
    }
}