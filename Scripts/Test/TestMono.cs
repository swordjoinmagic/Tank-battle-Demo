using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMono : MonoBehaviour {

    public float rotateSpeed = 20f;
    public float speed = 10f;

	// Update is called once per frame
	void Update () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.up,h*rotateSpeed*Time.deltaTime);
        transform.Translate(transform.forward*v*speed*Time.deltaTime);
	}
}
