using UnityEngine;
using System;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public GameObject effect;
	public string[] targetColliders;
	public float timeToExplode = 5;
	public int power = 2;

	float showTime;

	void Start () {
		showTime = Time.time;	
	}	

	void Update () {
		if (Time.time - showTime > timeToExplode)
			explode ();
	}

	void OnCollisionEnter (Collision collision) {
		if(Array.IndexOf(targetColliders, collision.gameObject.tag) != -1){
			collision.gameObject.GetComponent<EnemyBehaviour> ().hit(power);
			explode ();
		}	
	}

	void explode() {
		Instantiate (effect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
