using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {

	// Use this for initialization
	void Start () {
		float width = GetComponent<SpriteRenderer>().sprite.bounds.size.x;
		float height =  GetComponent<SpriteRenderer>().sprite.bounds.size.y;
		float worldheight = Camera.main.orthographicSize*2f;
		float worldwidth = worldheight/Screen.height*Screen.width;
		Vector3 tempscale = transform.localScale;
		tempscale.x= worldwidth/width;
		tempscale.y= worldheight/height;
		transform.localScale=tempscale;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
