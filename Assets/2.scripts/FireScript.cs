using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public GameObject tank;
	public GameObject firePoint;
	public Rigidbody projcetile;
	public float momentum = 30;

	Rigidbody tankRigidBody;
	Collider tankCollider;

	// Use this for initialization
	void Start () {
		tankRigidBody = tank.GetComponent<Rigidbody> ();
		tankCollider = tank.GetComponent<Collider> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Fire1"))
		{
			Rigidbody bullet = Instantiate(projcetile, firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
			Vector3 momentum_v = firePoint.transform.TransformDirection (new Vector3 (0, momentum, 0));
			bullet.velocity = momentum_v / bullet.mass;
			tankRigidBody.velocity += -momentum_v / tankRigidBody.mass;
			Physics.IgnoreCollision(tankCollider, bullet.GetComponent<Collider>());
		}

	
	}
}
