using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{ 
      public Camera mainCamera;
    public Camera subCamera;
    private bool mainCameraON = true;
    // ★追加
    public GameObject aimImage;

    void Start()
    {
        mainCamera.enabled = true;
        subCamera.enabled = false;
    
        // ★追加
        // 客観カメラの場合、照準器をオフにする。
        aimImage.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            mainCamera.enabled = false;
            subCamera.enabled = true;
            mainCameraON = false;

            // ★追加
            // 主観カメラの場合、照準器をオンにする。
            aimImage.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            mainCamera.enabled = true;
            subCamera.enabled = false;
            mainCameraON = true;

            // ★追加
            // 客観カメラの場合、照準器をオフにする。
            aimImage.SetActive(false);
        }
    }
}