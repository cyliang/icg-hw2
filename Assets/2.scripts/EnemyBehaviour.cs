using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public float speed;
	public float minDistance;
	public GameObject effect;

	PlayerBehaviour player;
	int life;

	void Start () {
		player = PlayerBehaviour.player;
		life = 20;
	}

	void Update () {
		transform.LookAt (player.transform, Vector3.up);
		if (Vector3.Distance (transform.position, player.transform.position) > minDistance)
			transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);
		else
			explode ();
	}

	public void hit(int hurt) {
		life -= hurt;
		if (life <= 0)
			explode ();
	}

	void explode() {
		Instantiate (effect, transform.position, transform.rotation);
		Destroy(gameObject);
	}
}
