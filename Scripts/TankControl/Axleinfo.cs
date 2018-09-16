using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 用来表示挂在一个轴上的左右车轮
/// </summary>
[System.Serializable]
public class Axleinfo {

    // 左轮
    public WheelCollider leftWheel;

    // 右轮
    public WheelCollider rightWheel;

    // 马力
    public bool motor;

    // 用于指明轮子是否转向
    public bool steering;
}
