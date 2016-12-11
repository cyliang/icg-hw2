using UnityEngine;
using System.Collections;

public class tankMove : MonoBehaviour {

	public float mSpeed = 1;
	public float rSpeed = 1;
	Rigidbody rigidBody;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (onGround) {
			rigidBody.AddRelativeForce (ControlScript.vertical * -rSpeed * Vector3.forward);
			rigidBody.AddTorque (ControlScript.horizontal * mSpeed * Vector3.up);
		}
	}

	bool onGround {
		get {
			return Physics.Raycast (transform.position + transform.forward * 3, Vector3.down, 1.2f)
				&& Physics.Raycast (transform.position - transform.forward * 3, Vector3.down, 1.2f); 
		}
	}
}