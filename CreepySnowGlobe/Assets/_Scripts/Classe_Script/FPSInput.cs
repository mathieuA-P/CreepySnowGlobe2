using UnityEngine;
using System.Collections;

public class FPSInput : MonoBehaviour {


	//Initialize variables
	public float walkSpeed = 6f;
	public float runSpeed = 12f;
	public float gravity = -9.8f;
	private CharacterController _charController;
	private Vector3 movement = Vector3.zero;
	private float speed = 0f;

	// Use this for initialization
	void Start () {
		speed = walkSpeed;
		_charController = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			speed = runSpeed;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift)) {
			speed = walkSpeed;
		}




		float deltaX = Input.GetAxis ("Horizontal") * speed;
		float deltaZ = Input.GetAxis ("Vertical") * speed;

		if (_charController.isGrounded) {
			movement = new Vector3 (deltaX, 0, deltaZ);
			movement = Vector3.ClampMagnitude (movement, speed);
			movement = transform.TransformDirection (movement);
			movement *= speed;
		}

		movement.y += gravity * Time.deltaTime;
		_charController.Move(movement * Time.deltaTime);
		//transform.Translate (deltaX + Time.deltaTime, 0, deltaY + Time.deltaTime);
	}
}