using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {
	
	public float speed;
	public float lifeCubeRotateSpeed;
	public GameObject effect;
	public GameObject lifeCube;

	PlayerBehaviour player;
	int life;
	Vector3 lifeCubeScale;
	Material lifeCubeMat;

	void Start () {
		player = PlayerBehaviour.player;
		life = 20;
		lifeCubeScale = lifeCube.transform.localScale;
		lifeCubeMat = lifeCube.GetComponent<Renderer> ().material;
	}

	void Update () {
		transform.LookAt (player.transform, Vector3.up);
		transform.position = Vector3.MoveTowards (transform.position, player.transform.position, speed * Time.deltaTime);

		Vector3 lifeRot = lifeCube.transform.localEulerAngles;
		lifeRot.y += Time.deltaTime * lifeCubeRotateSpeed;
		lifeCube.transform.localEulerAngles = lifeRot;

		float lifePercent = life / 20f;
		lifeCube.transform.localScale = Mathf.Lerp (0, 1, lifePercent) * lifeCubeScale;
		lifeCubeMat.color = Color.Lerp (Color.yellow, Color.red, lifePercent);
	}

	public void hit(int hurt) {
		life -= hurt;
		if (life <= 0)
			explode ();
	}

	public void explode() {
		Instantiate (effect, transform.position, transform.rotation);
		GameScript.enemyDied ();
		Destroy(gameObject);
	}
}
