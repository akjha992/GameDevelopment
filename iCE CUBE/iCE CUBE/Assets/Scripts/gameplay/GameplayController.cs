using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameplayController : MonoBehaviour {

	public GameObject gameOverPanel;
	public void go_back_to_main_menu()
	{	
		Time.timeScale=1;
		Debug.Log("clicked");
		gameOverPanel.SetActive(false);
		SceneManager.LoadScene("main",LoadSceneMode.Single);
	}
	public void retry()
	{
		Time.timeScale=1;
		Debug.Log("clicked");
		gameOverPanel.SetActive(false);
		SceneManager.LoadScene("start_screen",LoadSceneMode.Single);
	}
	void Start () {
		Debug.Log("skjdfb");
		gameOverPanel = GameObject.FindGameObjectWithTag("gameOverPanel");
		gameOverPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
