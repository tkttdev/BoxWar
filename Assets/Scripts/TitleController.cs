using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour {

	public void OnClick(){
		AudioSource audioSource = gameObject.GetComponent<AudioSource> ();
		audioSource.Play ();
		Animator animator = GameObject.Find ("Button").GetComponent<Animator> ();
		animator.SetBool ("isMove", true);
		Invoke ("MoveScene", 1.2f);
	}

	void MoveScene(){
		SceneManager.LoadScene ("StageSelect");
	}
}
