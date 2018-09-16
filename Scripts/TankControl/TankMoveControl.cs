using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMoveControl : MonoBehaviour {

    // 轮轴
    public List<Axleinfo> axleinfos;

    // 马力/最大马力
    private float motor = 0;
    public float maxMotorTorque;

    // 制动/最大制动
    private float breakTorque = 0;
    public float maxBreakTorque = 100;

    // 转向角/最大转向角
    private float steering = 0;
    public float maxSteeringAngle;

    private Rigidbody rigid;
    public Transform centerRigidbody;

    // 轮子
    private Transform wheels;

    // 履带
    private Transform tracks;

    /// <summary>
    /// 用于控制玩家移动
    /// </summary>
    public void PlayerCtrul() {
        // 获得马力和转向角
        motor = maxMotorTorque * Input.GetAxis("Vertical");
        steering = -maxSteeringAngle * Input.GetAxis("Horizontal");

        // 制动
        breakTorque = 0;
        foreach (var axlenInfo in axleinfos) {
            if (axlenInfo.leftWheel.rpm > 5 && motor < 0) {
                breakTorque = maxMotorTorque;
            } else if (axlenInfo.leftWheel.rpm < -5 && motor > 0) {
                breakTorque = maxMotorTorque;
            }
            
        }
    }

    /// <summary>
    /// 轮子旋转
    /// </summary>
    /// <param name="collider"></param>
    public void WheelsRotation(WheelCollider collider) {
        Vector3 posiiton;
        Quaternion rotation;
        collider.GetWorldPose(out posiiton,out rotation);
        foreach (Transform wheel in wheels) {
            wheel.rotation = rotation;
        }
    }

    public void TrackMove() {
        float offset = 0;
        offset = wheels.GetChild(0).localEulerAngles.x / 90f;
        foreach (Transform track in tracks) {

            // 获取材质
            MeshRenderer mr = track.gameObject.GetComponent<MeshRenderer>();

            if (mr == null) continue;

            Material material = mr.material;
            material.mainTextureOffset = new Vector2(0,offset);
        }
    }

    private void Start() {
        rigid = GetComponent<Rigidbody>();
        //rigid.centerOfMass = centerRigidbody.position;

        wheels = transform.Find("wheels");
        tracks = transform.Find("tracks");
    }

    // Update is called once per frame
    void Update () {
        PlayerCtrul();

        // 遍历车轴
        foreach (var axleInfo in axleinfos) {

            // 设置转向
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }

            // 设置马力
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }

            axleInfo.leftWheel.brakeTorque = breakTorque;
            axleInfo.rightWheel.brakeTorque = breakTorque;

            // 转动轮子
            WheelsRotation(axleInfo.leftWheel);
            TrackMove();
        }
	}
}
