using UnityEngine;
using System.Collections;

public class toScene6 : MonoBehaviour {

	void OnMouseEnter() { renderer.material.color = Color.red; }

	void OnMouseExit() { renderer.material.color = Color.white; }
	
	void OnMouseDown(){
		Application.LoadLevel("scene6");
	}
}
