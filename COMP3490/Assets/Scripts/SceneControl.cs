using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour {
	public InputField inputName;

	void start(){
		inputName = gameObject.GetComponent<InputField> ();
	}

	public void startGame(){
		//Debug.Log (inputName.text);
		UserData.setUserName (inputName.text);

		//Debug.Log (UserData.getUserName ());

		SceneManager.LoadScene (2);
	}

	public void restartGame(){
		SceneManager.LoadScene (2);
	}

	public void exitGame(){
		Application.Quit ();
	}

	public void newGame(){
		SceneManager.LoadScene (1);
	}

//	public void gameOver(){
//		SceneManager.LoadScene (3);
//	}

	public void levelCompleted(){
		SceneManager.LoadScene (4);
	}
}
