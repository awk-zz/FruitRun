using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoRotate : MonoBehaviour
{
    public float rotateSpeed = 100f;  // 旋转速度
    public bool isClockwise = true;  // 是否顺时针旋转

    void Update()
    {
        // 根据选择的旋转方向进行旋转
        if (isClockwise)
        {
            transform.Rotate(Vector3.forward * -rotateSpeed * Time.deltaTime);  // 顺时针旋转
        }
        else
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);  // 逆时针旋转
        }
    }
}
