using UnityEngine;
using System.Collections;

public class trackMove : MonoBehaviour {

	public float mSpeed = 10;
	public float rSpeed = 10;
	public GameObject barrel;

	void Start () {
	}

	void Update () {
		Vector3 towerRot = transform.localEulerAngles;
		towerRot.z += ControlScript.rotation * rSpeed * Time.deltaTime;
		transform.localEulerAngles = towerRot;

		Vector3 barrelEle = barrel.transform.localEulerAngles;
		barrelEle.x = Mathf.Clamp(barrelEle.x + ControlScript.elevation * mSpeed * Time.deltaTime, 0, 80);
		barrel.transform.localEulerAngles = barrelEle;
	}
}
