using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public GameObject tank;
	public GameObject firePoint;
	public Rigidbody projcetile;
	public float momentum = 30;

	Rigidbody tankRigidBody;
	Collider tankCollider;

	void Start () {
		tankRigidBody = tank.GetComponent<Rigidbody> ();
		tankCollider = tank.GetComponent<Collider> ();
	}

	void Update () {
		if(ControlScript.fire)
		{
			Rigidbody bullet = createBullet ();
			Vector3 momentum_v = firePoint.transform.TransformDirection (new Vector3 (0, momentum, 0));
			bullet.velocity = momentum_v / bullet.mass;
			tankRigidBody.velocity += -momentum_v / tankRigidBody.mass;
			Physics.IgnoreCollision(tankCollider, bullet.GetComponent<Collider>());
		}
	}

	Rigidbody createBullet() {
		Rigidbody bullet = Instantiate(projcetile, firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
		bullet.GetComponent<Renderer> ().material.color = Random.ColorHSV(0f, 1f, 0.8f, 1.0f, 0.7f, 1.0f);
		return bullet;
	}
}
