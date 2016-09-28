using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class StageSelectController : MonoBehaviour {

	//public GameObject stageNumCube;
	//private double degree;
	private float pushTime;

	void Start () {
		/*degree = 0.0f;
		for (int i = -2; i < 3; i++) {
			degree = i * 45.0f;
			Debug.Log (degree);
			Vector3 pos = new Vector3 (0, (4.0f) * (float)Math.Sin (degreeToRadian (degree)), (-4.0f) * (float)Math.Cos (degreeToRadian (degree)));
			GameObject obj = Instantiate (stageNumCube, pos, Quaternion.identity) as GameObject;
			obj.GetComponentInChildren<TextMesh> ().text = "STAGE " + i.ToString ();
			obj.transform.name = i.ToString ();
		}*/
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			pushTime = 0.0f;
			return;
		} else if (Input.GetMouseButton (0)) {
			pushTime += Time.deltaTime;
		} else if (Input.GetMouseButtonUp (0)) {
			if (pushTime > 1.0f) {
				return;
			}
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray, out hit)) {
				SceneManager.LoadScene ("Game");
			}
		}
	}

	/*double degreeToRadian(double deg){
		return deg * (Math.PI / 180.0f);
	}*/
}
