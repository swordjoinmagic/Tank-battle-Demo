using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour {

    // 炮台
    public Transform turret;
    // 炮管
    public Transform gun;

    // 炮台旋转速度
    public float turretRotSpeed = 20f;
    // 炮塔旋转速度
    public float gunRotSpeed = 5f;

    // 炮台目标角度
    public float turretRotTarget = 0;

    // 炮管旋转范围
    public float minRoll = -20f;
    public float maxRoll = 10f;

    // 旋转炮台
    public void TurretRotation() {
        Vector3 curretEuler = turret.transform.rotation.ToEuler();
        Vector3 cameraEuler = Camera.main.transform.rotation.ToEuler();

        Vector3 vector3 = new Vector3(curretEuler[0] * Mathf.Rad2Deg, cameraEuler[1] * Mathf.Rad2Deg, curretEuler[2] * Mathf.Rad2Deg);

        Quaternion quaternion = Quaternion.Euler(vector3);

        turret.rotation = Quaternion.Lerp(turret.rotation, quaternion, Time.deltaTime * turretRotSpeed);
    }

    public void GunRotation() {
        // 摄像机在x轴上的旋转角度
        float xRotation = Camera.main.transform.rotation.eulerAngles.x;
        if (xRotation > 180)
            xRotation -= 360f;

        // 跟原先旋转角的差值
        float different = xRotation - 30f;

        // 最终要旋转的角度
        float angles = Mathf.Clamp(different, minRoll, maxRoll);

        Vector3 gunEuler = gun.transform.rotation.eulerAngles;
        Quaternion quaternion = Quaternion.Euler(angles,gunEuler[1], gunEuler[2]);

        gun.rotation = Quaternion.Lerp(gun.rotation, quaternion, Time.deltaTime * gunRotSpeed);
    }


    private void LateUpdate() {
        TurretRotation();
        GunRotation();
    }
}
