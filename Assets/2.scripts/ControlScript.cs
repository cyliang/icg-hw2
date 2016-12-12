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

	void Start() {
		instance = this;
	}

	void Update() {
		if (!useScreenBtn) {
			fire = Input.GetKeyDown (KeyCode.LeftControl);
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
