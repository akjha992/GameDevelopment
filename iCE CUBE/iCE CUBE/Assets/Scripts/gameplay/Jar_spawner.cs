using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_spawner : MonoBehaviour {

	public GameObject last_jar;
	public static int level;
	public GameObject prefab;
	void Start()
	{
		level=5;
	}
	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log(other.tag);
		if(other.gameObject==last_jar)
		{
			//Debug.Log(true);
			GameObject g =  (GameObject)Instantiate(prefab, new Vector3(0,0, 0), Quaternion.identity);

			GameObject c1 = g.transform.GetChild (0).gameObject;
			GameObject c2 = g.transform.GetChild (1).gameObject;
			c1.GetComponent<Jar>().set_level(level);
			c2.GetComponent<Stand>().set_level(level);
			c2.GetComponent<Stand>().jar=c1.GetComponent<Jar>();
		//	g[1].transform.position = (g[1].transform.position.x, g[1].transform.position.y+pos,g[1].transform.position.z);
			last_jar=c1;
			level++;
		}
	}
}
