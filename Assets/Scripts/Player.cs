using UnityEngine;
using System.Collections;

public class Player : BaseOfCube {

	Vector3 lastPos;
	Vector3 dis;
	Vector3 mousePosition;

	// Use this for initialization
	void Start () {
		this.initCube ("Enemy_Bullet");
		StartCoroutine ("Fire");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			var screenSpace = Camera.main.WorldToScreenPoint(transform.position);
			var downPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			lastPos = Camera.main.ScreenToWorldPoint(downPos);
			return;
		}
		if (Input.GetMouseButton (0)) {
			var screenSpace = Camera.main.WorldToScreenPoint(transform.position);
			var downPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);
			dis = lastPos - Camera.main.ScreenToWorldPoint (downPos);
			lastPos = Camera.main.ScreenToWorldPoint (downPos);
			gameObject.transform.position = gameObject.transform.position - dis;
		}
	}
}
