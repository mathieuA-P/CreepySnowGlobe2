using UnityEngine;
using System.Collections;

public class MouseLook : MonoBehaviour {


	//Initialize variables
	public enum RotationAxes {
		MouseXandY = 0,
		MouseX = 1,
		MouseY = 2
	}
			
	public RotationAxes axes = RotationAxes.MouseXandY;
	public float sensitivityhor = 3.0f;
	public float sensitivityVert = 3.0f;
	public MoveCamera _moveCameraRef;

	public float minimumVert = -45.0f;
	public float maximumVert = 45.0f;

	private float _rotationX = 0;
	void Update () {
		



			if (axes == RotationAxes.MouseX) {
				transform.Rotate (0, Input.GetAxis ("Mouse X") * sensitivityhor, 0);
			} else if (axes == RotationAxes.MouseY) {
				_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

				float rotationY = transform.localEulerAngles.y;

				transform.localEulerAngles = new Vector3 (_rotationX, rotationY, 0);
			} else {
				_rotationX -= Input.GetAxis ("Mouse Y") * sensitivityVert;
				_rotationX = Mathf.Clamp (_rotationX, minimumVert, maximumVert);

				float delta = Input.GetAxis ("Mouse X") * sensitivityhor;
				float rotationy = transform.localEulerAngles.y + delta;

				transform.localEulerAngles = new Vector3 (_rotationX, rotationy, 0);
			}
		
		
		
}
}
