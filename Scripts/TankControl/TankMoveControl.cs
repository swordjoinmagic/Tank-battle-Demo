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

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
