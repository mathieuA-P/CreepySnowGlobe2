using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public bool mode3D = true;
	public bool atPlayer = true;
	public float speed = 0.1f;
	public Transform position2DRef;
	public MeshRenderer postCardIrlMeshRendRef;
	public PostCardAnim _postCardAnim;
	public GameObject postCardRef;


	private float t = 0f;
	private float customTimer = 1f;
	private float distanceOffSet = 30;
	private Vector3 starPos;
	private Vector3 newPosition;
	private bool makeItMove = false;
	// Use this for initialization
	void Start () {
		GameObject playerRef = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		GameObject playerRef = GameObject.Find ("Player");
		if (Input.GetKeyDown (KeyCode.Z)) {
			if (mode3D) {
				_postCardAnim.PlayPostCardAnim ();

			}
			else if (!mode3D && !makeItMove) {
				transform.LookAt (playerRef.transform);
				Vector3 starPos = transform.position;
				Vector3 newposition = playerRef.transform.position;
				makeItMove = true;
				//postCardIrlMeshRendRef.enabled = true;
				customTimer = 1f;

			}

		}







		if (makeItMove){
			transform.Translate (Vector3.forward * speed);
			customTimer -= Time.deltaTime;
			float distance = Vector3.Distance (transform.position, playerRef.transform.position);
			if (distance <= distanceOffSet){
				makeItMove = false;
				atPlayer = true;
				mode3D = true;
				PlaceCameraOnPlayer ();
			}
		}


	}

	void PlaceCameraOnPlayer(){
		GameObject playerRef = GameObject.Find ("Player");
		transform.position = playerRef.transform.position;

	}

	public void PostCardAnimFinish(){
				print ("anim stoped");
				postCardIrlMeshRendRef.enabled = false;
				mode3D = false;
				atPlayer = false;
				transform.position = position2DRef.position;
				transform.rotation = position2DRef.rotation;
	}


}
