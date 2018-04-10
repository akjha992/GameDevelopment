using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar : MonoBehaviour {

	[SerializeField]
	private float angular_velocity = 2f;
	[SerializeField]
	private int level;
	public static float base_height = -5f;
	public static float min_height = .4f;
	public static float level_height = 2.5f;
	public static float min_x = -2.15f;
	public static float max_x = 2.15f;
	private float time;
	private bool shm=false; 
	[SerializeField]
	public int state;
	/*
		Number of states
		0: Ball is below the jar,polygon collider2d isTrigger is true, isSHM is false 
		1: Ball is above the jar,polygon collider2d isTrigger is false, isSHM is false 
		2: Ball is in the jar,polygon collider2d isTrigger is false, isSHM is true 
		3: Ball was in the jar and now fired from it, polygon collider2d isTrigger is false, isSHM is true 
	*/
	public void set_level(int level)
	{
		this.level=level;
	}
	void loose_collider(bool state)
	{
		GetComponent<PolygonCollider2D>().isTrigger=state;
	}
	void start_SHM()
	{
		if(!shm)
		time=Mathf.Asin(transform.position.x/max_x)/angular_velocity;
		shm=true;
	}
	void stop_SHM()
	{
		shm=false;
	}
	public void change_state(int state)
	{
		this.state=state;
		switch(state)
		{
			case 0: {
				loose_collider(true);
				stop_SHM();
				break;
			}
			case 1:{
				loose_collider(false);
				stop_SHM();
				break;	
			}
			case 2:{
				loose_collider(false);
				start_SHM();	
				break;
			}
			case 3:{
				loose_collider(false);
				start_SHM();
				break;
			}
		}
	}
	void Start()
	{
		float gap = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		float worldheight = Camera.main.orthographicSize*2f;
		float worldwidth = worldheight/Screen.height*Screen.width;
		max_x=(worldwidth-gap)/2;
		min_x=-max_x;
		int r = Random.Range(0,2);
			if(r==0)
		angular_velocity=angular_velocity*-1;
		transform.position = new Vector3(Random.Range(min_x,max_x),+base_height+min_height+level_height*level,transform.position.z);
		if(this.gameObject==ObjectManager.cur_jar.gameObject)
		change_state(2);
		else
		change_state(0);
	}
	void Update()
	{
		
		if(shm)
		{
			time=time+Time.deltaTime;

			transform.position = new Vector3(max_x*Mathf.Sin(angular_velocity*time),transform.position.y,transform.position.z);
		}
	}
}
