using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameScript : MonoBehaviour {

	public Camera[] cameras;
	public GameObject enemyTemplate;
	public Text killText;
	public float enemyMaxScale = 1f, enemyMinScale = 1f;
	public float enemyShowInterval = 5;

	GameObject enemies;
	float enemyShowTime;
	static int kills;
	static Text _killText;

	void Start () {
		enemies = new GameObject ("Enemies");
		enemyShowTime = Time.time;
		kills = 0;
		_killText = killText;
	}

	void Update () {
		if (Time.time - enemyShowTime >= enemyShowInterval) {
			createRandomEnemy ();
			enemyShowTime = Time.time;
		}

		if (!cameras [ControlScript.vision].gameObject.activeSelf) {
			foreach (Camera cam in cameras) {
				cam.gameObject.SetActive (cam == cameras[ControlScript.vision]);
			}
		}
	}

	void createRandomEnemy() {
		GameObject enemy = Instantiate (enemyTemplate, enemies.transform, true) as GameObject;
		enemy.transform.localScale *= Random.Range (enemyMinScale, enemyMaxScale);
	}

	static public void enemyDied() {
		kills++;
		_killText.text = "Enemy Kills: " + kills;
	}
}
