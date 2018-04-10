using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jar_destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log(other.GetType());
		Destroy(other.gameObject);
	}
}
