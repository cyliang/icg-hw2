using UnityEngine;
using System.Collections;

public class ControlScript : MonoBehaviour {
	public bool useScreenBtn = false;

	static protected ControlScript instance;

	static public float horizontal { get; private set; }
	static public float vertical { get; private set; }
	static public float rotation { get; private set; }
	static public float elevation { get; private set; }
	static public bool fire { get; private set; }
	static public int selectedBullet { get; private set; }
	static public int vision { get; private set; }

	void Start() {
		instance = this;
		selectedBullet = 2;
		vision = 0;
	}

	void Update() {
		if (!useScreenBtn) {
			fire = Input.GetButtonDown ("Fire1");

			if (Input.GetKeyDown (KeyCode.Alpha1))
				selectedBullet = 1;
			else if (Input.GetKeyDown (KeyCode.Alpha2))
				selectedBullet = 2;
			else if (Input.GetKeyDown (KeyCode.Alpha3))
				selectedBullet = 3;

			if (Input.GetKeyDown (KeyCode.V)) {
				vision = (vision + 1) % 2;
			}
		}
	}

	void FixedUpdate() {

		if (!useScreenBtn) {
			horizontal = Input.GetAxis ("Horizontal");
			vertical = Input.GetAxis ("Vertical");

			if (Input.GetKey (KeyCode.E))
				rotation = 1f;
			else if (Input.GetKey (KeyCode.Q))
				rotation = -1f;
			else
				rotation = 0f;

			if (Input.GetKey (KeyCode.PageUp))
				elevation = 1f;
			else if (Input.GetKey (KeyCode.PageDown))
				elevation = -1f;
			else
				elevation = 0f;
		}
	}
}
