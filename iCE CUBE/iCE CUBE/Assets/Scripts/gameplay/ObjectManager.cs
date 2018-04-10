using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ObjectManager : MonoBehaviour {
	

	public static Jar cur_jar;
	private GameObject panel;
	//public static Stand cur_stand;
	private GameObject ball;
	[SerializeField]
	private Stand[] stands;
	[SerializeField]
	private Jar[] jars;

	//////Test
	public float cur_jar_height;
	//////

	void position_jars()
	{
		cur_jar=jars[0];
		for(int i=0;i<jars.Length;i++)
		{	
			jars[i].set_level(i);
		}
	}
	void position_stands()
	{
	//	cur_stand=stands[0];

		for(int i=0;i<stands.Length;i++)
		{	
			stands[i].set_level(i);
			stands[i].jar=jars[i];
		}
	}
	void Start () {
		position_stands();
		position_jars();
//		ball = GameObject.FindWithTag("ball");
//		Vector3 temp = ball.transform.position;
//		temp=new Vector3(cur_jar.transform.position.x,cur_jar.transform.position.y+.10f,temp.z);
//		//ball.transform.position=temp;
//		//Ball_movement.hard_stick=true;
	}
	
	// Update is called once per frame
	void Update () {
		cur_jar_height=cur_jar.transform.position.y;

	}
}
