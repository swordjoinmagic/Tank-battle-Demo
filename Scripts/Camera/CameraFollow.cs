using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // 相机距离单位的距离
    public float distance = 15f;

    // 横向角度
    public float rot = 0;

    // 纵向角度
    public float roll = 30f;

    // 横向旋转速度
    public float rotSpeed = 0.2f;

    // 目标物体
    public GameObject target;

    // 纵向角度范围
    private float maxRoll = 70f;
    private float minRoll = -10f;
    // 纵向旋转速度
    public float rollSpeed = 2f;

    // 距离范围
    public float maxDistance = 22f;
    public float minDistance = 5f;
    // 距离变化速度
    public float zommSpeed = 2f;

    // 调整摄像机与目标单位的距离
    public void Zoom() {
        distance -= Input.GetAxis("Mouse ScrollWheel")*zommSpeed;
    }

    // 横向旋转
    void RotRotate() {
        float w = Input.GetAxis("Mouse X") * rotSpeed;
        rot += w;
    }

    // 纵向旋转
    void RollRotate() {
        float w = Input.GetAxis("Mouse Y") * rollSpeed;
        roll = Mathf.Clamp(roll-w,minRoll,maxRoll);
    }

    private void LateUpdate() {

        RotRotate();
        RollRotate();
        Zoom();

        // 目标的坐标
        Vector3 targetPos = target.transform.position;

        // 用三角函数计算相机位置
        float d = distance * Mathf.Cos(roll*Mathf.Deg2Rad);
        float height = distance * Mathf.Sin(roll*Mathf.Deg2Rad);

        Vector3 cameraPos = new Vector3(
            targetPos.x - d * Mathf.Sin(rot*Mathf.Deg2Rad),
            targetPos.y + height,
            targetPos.z - d * Mathf.Cos(rot*Mathf.Deg2Rad)
        );
        Camera.main.transform.position = cameraPos;

        // 对准目标
        Camera.main.transform.LookAt(target.transform);

    }
}
