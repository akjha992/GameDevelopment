using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class Ball : MonoBehaviour {

	[SerializeField]
	private int state;
	public bool clickable;
	GameObject gameplayController;
	private ScoreManager scoremanager;
	Vector3 cam_position;
	/*
	0: ball is in the cur jar
	1: ball is in air
	*/
	[SerializeField]
	private bool stick_to_cur_jar=false;
	[SerializeField]
	private bool permanent_stick_to_cur_jar=false;
	//test variable
	public GameObject cur_jar;
	//test variable
//	void OnTriggerExit2D(Collider2D other)
//	{
//		if (other.tag == "stand")
//		{
//			if(GetComponent<Rigidbody2D>().velocity.y<0)
//			{
//				
//				Stand x = other.gameObject.GetComponent<Stand>();
//				if(x.jar==ObjectManager.cur_jar)
//				{
//					Debug.Log("Game Over");
//					//Debug.Log(Time.timeScale);
//					Time.timeScale=0;
//					gameplayController.GetComponent<GameplayController>().gameOverPanel.SetActive(true);
//				}
//			}
//		}
//	}
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log(other.GetType());
		if (other.tag == "stand")
		{
			if(GetComponent<Rigidbody2D>().velocity.y<0)
			{
				
				Stand x = other.gameObject.GetComponent<Stand>();
				if(x.jar==ObjectManager.cur_jar)
				{
					Debug.Log("Game Over");
					//Debug.Log(Time.timeScale);
					Time.timeScale=0;
					gameplayController.GetComponent<GameplayController>().gameOverPanel.SetActive(true);
				}
				else
				{
					Debug.Log("ball going down from upper stand");
					x.jar.change_state(0);
				}
			}
		}
		else if (other.GetType() == typeof(EdgeCollider2D))
		{
			if(GetComponent<Rigidbody2D>().velocity.y<0&&state!=0)
			{
				if(other.gameObject.GetComponent<Jar>()!=ObjectManager.cur_jar)
				{
					scoremanager.incrementScore();
				}
			}
			if(GetComponent<Rigidbody2D>().velocity.y<0)
			{
				Debug.Log("Inside new jar ball coming down");
				ObjectManager.cur_jar=other.gameObject.GetComponent<Jar>();
				GetComponent<Rigidbody2D>().freezeRotation=true;
				transform.rotation = new Quaternion(0,0,0,0);
				//GetComponent<Rigidbody2D>().velocity=new Vector2(0,0);
				change_state(0);
			}

		}
		else if (other.GetType() == typeof(BoxCollider2D))
		{
			if(GetComponent<Rigidbody2D>().velocity.y>0)
			{
				Jar x = other.gameObject.GetComponent<Jar>();
				if(x==ObjectManager.cur_jar)
				{
					Debug.Log("Above current jar ball going up");
					GetComponent<Rigidbody2D>().freezeRotation=false;
					x.change_state(3);
				}
				else
				{
					Debug.Log("Above new jar ball going up");
					x.change_state(1);
				}

			}
//			else if(other.gameObject.GetComponent<Jar>()==ObjectManager.cur_jar)
//			{
//				SceneManager.LoadScene("loose_screen",LoadSceneMode.Single);
//			}
		}
	}
	void move_ball()
	{
		//unstick
		stick_to_cur_jar=false;
		permanent_stick_to_cur_jar=false;	
		//GetComponent<Rigidbody2D>().bodyType=RigidbodyType2D.Dynamic;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,15f);
	}
    void stick()
	{
		if(!stick_to_cur_jar)
		stick_to_cur_jar=true;
		//GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		GameObject cam = GameObject.FindWithTag("MainCamera");
		Vector3 temp = cam.transform.position;
		cam_position = new Vector3(temp.x,ObjectManager.cur_jar.transform.position.y+3.92f,temp.z);
		ObjectManager.cur_jar.change_state(2);
		//cam.transform.position = temp;
	}
	public void change_state(int state)
	{
		if(state!=this.state)
		{
			this.state=state;
			switch(state)
			{
				case 0:{
					stick();
					break;
				}
				case 1:{
					move_ball();
					break;
				}
			}
		}
	}
	void Start()
	{
		gameplayController = GameObject.FindGameObjectWithTag("gameplayController");
		scoremanager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
		clickable=true;
		change_state(0);
		cam_position=new Vector3(0,0,-10f);
	}
	void Update()
	{
		GameObject cam = GameObject.FindWithTag("MainCamera");
		cam.transform.position = Vector3.Lerp(cam.transform.position, cam_position, Time.deltaTime * 3f);
		cur_jar=ObjectManager.cur_jar.gameObject;
		if(stick_to_cur_jar)
		{
			Vector3 temp =transform.position;
			temp=new Vector3(cur_jar.transform.position.x,cur_jar.transform.position.y+.15f,temp.z);
			if(Convert.ToInt32((transform.position.y-cur_jar.transform.position.y)*10)==2)
			{
				stick_to_cur_jar=false;
				permanent_stick_to_cur_jar=true;	
			}
//			else
//				transform.position = Vector3.Lerp(transform.position, temp, Time.deltaTime * .2f);
		}
		else if(permanent_stick_to_cur_jar)
		{
			Vector3 temp =transform.position;
			//transform.position = Vector3.Lerp(transform.position, temp, Time.deltaTime * 100f);
			temp=new Vector3(cur_jar.transform.position.x,cur_jar.transform.position.y+.15f,temp.z);
			transform.position=temp;
			clickable=true;
		}
		if(Input.GetMouseButtonDown(0)&&clickable)
		{
			change_state(1);
			clickable=false;
		}
	} 
}
