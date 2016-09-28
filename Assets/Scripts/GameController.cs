using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public float interval;
	public GameObject enemy;
	public Text scoreText;
	private int score;

	// Use this for initialization
	void Start () {
		StartCoroutine ("generateEnemy");
		score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator generateEnemy() {
		for (;;) {
			Instantiate (enemy, Camera.main.ScreenToWorldPoint (new Vector3 (Random.Range(0,Screen.width) ,Screen.height ,13)), Quaternion.Euler (-180, 0, 0));
			yield return new WaitForSeconds (interval);
		}
	}

	public void addScore(int addPoint){
		score += addPoint;
		scoreText.text = "SCORE : " + score.ToString ();
	}
}
