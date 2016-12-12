using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerBehaviour : MonoBehaviour {

	static public PlayerBehaviour player { get; private set; }
	public GameObject bleedPanel;
	public Text lifeText;
	public float mSpeed = 1;
	public float rSpeed = 1;
	Rigidbody rigidBody;
	float bleedTimeout;
	int life;

	void Start () {
		player = this;
		rigidBody = GetComponent<Rigidbody> ();
		life = 100;
		bleedTimeout = 0;
		bleedPanel.SetActive (false);
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.tag == "enemy") {
			collision.gameObject.GetComponent<EnemyBehaviour> ().explode ();
			hurt ();
		}
	}
		
	void FixedUpdate () {
		if (onGround) {
			rigidBody.AddRelativeForce (ControlScript.vertical * -rSpeed * Vector3.forward);
			rigidBody.AddTorque (ControlScript.horizontal * mSpeed * Vector3.up);
		}
	}

	void Update() {
		if (bleedTimeout > 0) {
			bleedTimeout -= Time.deltaTime;
			if (bleedTimeout <= 0)
				bleedPanel.SetActive (false);
		}
	}

	void hurt() {
		bleedTimeout = 0.1f;
		bleedPanel.SetActive (true);
		life--;

		lifeText.text = "Life: " + life;
	}

	bool onGround {
		get {
			return Physics.Raycast (transform.position + transform.forward * 3, Vector3.down, 2f)
				&& Physics.Raycast (transform.position - transform.forward * 3, Vector3.down, 2f); 
		}
	}
}