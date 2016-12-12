using UnityEngine;
using System;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {
	public GameObject effectTemplate;
	public string[] targetColliders;
	public float timeToExplode = 5;
	public int power = 2;

	float showTime;
	Color color;

	void Start () {
		showTime = Time.time;

		color = UnityEngine.Random.ColorHSV(0f, 1f, 0.8f, 1.0f, 0.7f, 1.0f);
		GetComponent<Renderer> ().material.color = color;
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
		GameObject effect = Instantiate (effectTemplate, transform.position, transform.rotation) as GameObject;
		effect.GetComponent<Renderer>().material.SetColor("_TintColor", color);
		Destroy(gameObject);
	}
}
