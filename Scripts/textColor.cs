using UnityEngine;
using System.Collections;

public class textColor : MonoBehaviour {

	void Awake() 
    {
        renderer.material.color = Color.blue;
    }
}
