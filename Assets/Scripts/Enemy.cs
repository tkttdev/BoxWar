using UnityEngine;
using System.Collections;

public class Enemy : BaseOfCube {

	private int actionSelectNum;
	private float stayScreenTime;

	// Use this for initialization
	void Start () {
		this.initCube ("Player_Bullet");
		StartCoroutine ("Fire");
		actionSelectNum = Random.Range (1, 4);
		stayScreenTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		stayScreenTime += Time.deltaTime;
		switch (actionSelectNum) {
		case 1:
			action1 ();
			break;
		case 2:
			action2 ();
			break;
		case 3:
			action3 ();
			break;
		case 4:
			action4 ();
			break;
		case 5:
			action5 ();
			break;
		}
		disicionScreenOut ();
	}

	void action1(){
		if(stayScreenTime >= 4.0f){
			gameObject.transform.position -= transform.forward * Time.deltaTime * 2;
		} else if (gameObject.transform.position.z > Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height / 2, 13)).y && stayScreenTime < 4.0f) {
			gameObject.transform.position += transform.forward * Time.deltaTime * 2;
		}
	}

	void action2(){
		if(stayScreenTime >= 4.0f){
			gameObject.transform.position -= new Vector3 (1, 0, -1) * Time.deltaTime * 2;
		} else if (gameObject.transform.position.z > Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height / 2, 13)).y && stayScreenTime < 4.0f) {
			gameObject.transform.position += transform.forward * Time.deltaTime * 2;
		}
	}

	void action3(){
		if(stayScreenTime >= 4.0f){
			gameObject.transform.position -= new Vector3 (-1, 0, -1) * Time.deltaTime * 2;
		} else if (gameObject.transform.position.z > Camera.main.ScreenToWorldPoint (new Vector3 (0, Screen.height / 2, 13)).y && stayScreenTime < 4.0f) {
			gameObject.transform.position += transform.forward * Time.deltaTime * 2;
		}
	}

	void action4(){
	}

	void action5(){
	}

	void disicionScreenOut(){
		if (gameObject.transform.position.z > Camera.main.ViewportToWorldPoint (new Vector3 (1, 1, 5)).y) { //ちょっと判定が謎い，なぜz=5?
			Destroy (gameObject);
		}
	}
}
