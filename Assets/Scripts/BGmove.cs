using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGmove : MonoBehaviour
{
    public Transform cameraTransform; // 鏡頭的 Transform

    private float initialY; // 保存背景的初始 Y 軸位置
    private float initialZ; // 保存背景的初始 Z 軸位置

    void Start()
    {
        // 保存背景的初始 Y 和 Z 位置
        initialY = transform.position.y;
        initialZ = transform.position.z;
    }

    void Update()
    {
        // 獲取鏡頭在 X 軸上的位置
        float cameraX = cameraTransform.position.x;

        // 設置背景的新位置，只更新 X 軸
        transform.position = new Vector3(cameraX, initialY, initialZ);
    }
}