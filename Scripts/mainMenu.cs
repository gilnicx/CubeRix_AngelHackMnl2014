using UnityEngine;
using System.Collections;

public class mainMenu : MonoBehaviour {
	
	
	void Awake() 
    {
        renderer.material.color = Color.red;
    }
	
	void OnMouseEnter() { renderer.material.color = Color.green; }

	void OnMouseExit() { renderer.material.color = Color.red; }
	
	void OnMouseDown(){
		Application.LoadLevel("scene1");
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
