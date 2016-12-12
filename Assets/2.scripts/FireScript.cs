using UnityEngine;
using System.Collections;

public class FireScript : MonoBehaviour {

	public GameObject tank;
	public GameObject firePoint;
	public Rigidbody bulletTemplate1;
	public Rigidbody bulletTemplate2;
	public Rigidbody bulletTemplate3;
	public float momentum = 30;

	Rigidbody[] bulletTemplates;
	Rigidbody tankRigidBody;
	Collider tankCollider;

	void Start () {
		tankRigidBody = tank.GetComponent<Rigidbody> ();
		tankCollider = tank.GetComponent<Collider> ();
		bulletTemplates = new Rigidbody[] {
			bulletTemplate1, 
			bulletTemplate2,
			bulletTemplate3
		};
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
		Rigidbody bullet = Instantiate(
			bulletTemplates[ControlScript.selectedBullet - 1], 
			firePoint.transform.position, firePoint.transform.rotation) as Rigidbody;
		
		return bullet;
	}
}
