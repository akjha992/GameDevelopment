using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour {

	public int score=-1;
	public int highscore;
	private GameObject finalScore;
	private GameObject highScore;
	public void incrementScore()
	{
		score++;
		if(highscore<score)
		highscore=score;
		GetComponent<Text>().text=score.ToString();

	}
	public void updateScore()
	{
		GetComponent<Text>().text=score.ToString();
	}
	void Start()
	{
		if (PlayerPrefs.HasKey("highScore") )
		{
			highscore = PlayerPrefs.GetInt("highScore");
		}

		updateScore();
	}
	void Update()
	{
		PlayerPrefs.SetInt("highScore", highscore);
		finalScore = GameObject.FindGameObjectWithTag("finalScoreText");
		highScore = GameObject.FindGameObjectWithTag("highScoreText");
		if(finalScore!=null)
		{
			finalScore.GetComponent<Text>().text = "Score :  "+ score;
			highScore.GetComponent<Text>().text = "Best :  "+ highscore;
		}
	}
}
