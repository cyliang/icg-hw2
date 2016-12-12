using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public GameObject enemyTemplate;
	public float enemyMaxScale = 1f, enemyMinScale = 1f;
	public float enemyShowInterval = 5;

	GameObject enemies;
	float enemyShowTime;

	void Start () {
		enemies = new GameObject ("Enemies");
		enemyShowTime = Time.time;
	}

	void Update () {
		if (Time.time - enemyShowTime >= enemyShowInterval) {
			createRandomEnemy ();
			enemyShowTime = Time.time;
		}
	}

	void createRandomEnemy() {
		GameObject enemy = Instantiate (enemyTemplate, enemies.transform, true) as GameObject;
		enemy.transform.localScale *= Random.Range (enemyMinScale, enemyMaxScale);
	}
}
