using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class start_button : MonoBehaviour {

	public void start_game()
	{
		SceneManager.LoadScene("start_screen",LoadSceneMode.Single);
	}
}
