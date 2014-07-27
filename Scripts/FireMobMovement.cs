using UnityEngine;
using System.Collections;

public class FireMobMovement : MonoBehaviour {
	
	public static GameObject target;
	// Use this for initialization
	void Start () {
		
		if (target != null){
		transform.position = target.transform.position;
		transform.eulerAngles = target.transform.eulerAngles;
		StartCoroutine("Destroy");
		}
	}
	
	private IEnumerator Destroy()
	{
	    yield return new WaitForSeconds(3.0f);
	    Destroy(this.gameObject);
	} 
	
	// Update is called once per frame
	void Update () {
	
		transform.Translate(Vector3.forward * (Time.deltaTime * 5.0f ));
	}
	

	
}
