using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
	public int damage;

	void Update(){
		if (Camera.main.WorldToScreenPoint (gameObject.transform.position).y > Screen.height)
			Destroy (gameObject);
	}

	public int getDamage(){
		return damage;
	}

	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == "Enemy_Bullet" || collision.transform.tag == "Player_Bullet") {
			gameObject.GetComponent<Rigidbody> ().useGravity = true;
		} else {
			Destroy (gameObject);
		}
	}
}
