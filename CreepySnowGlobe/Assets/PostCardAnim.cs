using UnityEngine;
using System.Collections;

public class PostCardAnim : MonoBehaviour {

	public void PlayPostCardAnim(){
		GetComponent<Animation> ().Play ();
	}

	public void AfterAnim(){
		GameObject cameraRef = GameObject.Find ("Main Camera");
		MoveCamera _moveCameraRef = cameraRef.GetComponent<MoveCamera> ();
		_moveCameraRef.PostCardAnimFinish ();
	}
}
