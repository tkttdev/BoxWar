using UnityEngine;
using System.Collections;
using System;
using UnityEngine.SceneManagement;

public class BaseOfCube : MonoBehaviour {

	public GameObject bullet;
	public float interval;
	public int maxHP;
	public int HP;
	private String enemyBulletName;
	private GameController gameController;

	void Awake(){
	}

	public void initCube(String enyBltName){
		HP = maxHP;
		enemyBulletName = enyBltName;
	}

	public void setBullet(String prefabPass) {
		bullet = Resources.Load (prefabPass) as GameObject;
	}

	private void takeDamage(int damage){
		HP -= damage;
	}

	public int getHP(){
		return HP;
	}

	public IEnumerator Fire(){
		for (;;) {
			AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
			audioSource.Play ();
			GameObject blt = Instantiate (bullet, gameObject.transform.position + gameObject.transform.forward, Quaternion.identity) as GameObject;
			blt.GetComponent<Rigidbody> ().velocity = gameObject.transform.forward * 8.0f;
			Destroy (blt, 3.0f);
			yield return new WaitForSeconds (interval);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.transform.tag == enemyBulletName) {
			Debug.Log ("damage");
			Bullet blt = collision.gameObject.GetComponent<Bullet> ();
			takeDamage (blt.getDamage());
		}
		if (HP <= 0) {
			GameController gmoCon = GameObject.Find ("GameController").GetComponent<GameController> ();
			gmoCon.addScore (20);
			Destroy (gameObject);
		}
	}
}
