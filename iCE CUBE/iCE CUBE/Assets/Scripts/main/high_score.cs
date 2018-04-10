using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class high_score : MonoBehaviour {

	private int highscore;
	void Start()
	{
		if (PlayerPrefs.HasKey("highScore") )
		{
			highscore = PlayerPrefs.GetInt("highScore");
		}
		GetComponent<Text>().text="Best : "+highscore;
	}
}
