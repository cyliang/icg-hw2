using UnityEngine;
using System.Collections;

public class trackMove : MonoBehaviour {

	public float mSpeed = 1;
	public float rSpeed = 1;

	float towerSpeed = 1;

	public GameObject barrel;//砲管
	float barrelSpeed = 30;
	float maxAngle = 80;
	float minAngle = -5;
	float angle;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 towerRot = transform.localEulerAngles;
		towerRot.z += ControlScript.rotation;
		transform.localEulerAngles = towerRot;

		Vector3 barrelEle = barrel.transform.localEulerAngles;
		barrelEle.x += ControlScript.elevation;
		barrel.transform.localEulerAngles = barrelEle;
	}
}
