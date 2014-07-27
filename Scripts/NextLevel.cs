using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {
	
	public float delay ;
	public string levelName;
	
	void Start () {
		
		StartCoroutine("Goto");
	}
	
	private IEnumerator Goto()
	{
	    yield return new WaitForSeconds(delay);
	    Application.LoadLevel(levelName);
	} 
}
