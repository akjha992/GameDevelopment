using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stand : MonoBehaviour {

	
	[SerializeField]
	private int level;
	public Jar jar;
	public void set_level(int level)
	{
		this.level=level;
	}
	void Start()
	{
		transform.position = new Vector3(0,Jar.base_height+Jar.min_height+Jar.level_height*level,0);
	}
	

	void Update () {
		
	}
}
