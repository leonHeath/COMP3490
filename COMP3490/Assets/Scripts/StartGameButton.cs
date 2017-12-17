using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour {
	public InputField inputName;

	void start(){
		inputName = gameObject.GetComponent<InputField> ();
	}

	public void assignUserName(){
		Debug.Log (inputName.text);
		UserData.setUserName (inputName.text);

		Debug.Log (UserData.getUserName ());

		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}
}
