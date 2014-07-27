using UnityEngine;
using System.Collections;

public class PlayerMove: MonoBehaviour {

	public GameObject PlayerMesh;
	public AnimationClip WalkingAnimation;
	public AnimationClip JumpingAnimation;
	public AnimationClip FireAnimation;
	public GameObject InstatiateHere;
	private GameObject Fire;
	private double Health = 50;
	
	private int countCollect = 0;
	
	private string box1 = "If a < b, \nexchange \na and b";
	private string box2 = "Divide a by b \nand get the \nremainder, r. \n If r = 0, \nreport b as the \nGCD of a & b";
	private string box3 = "Replace a by b \n& replace b by \nr. \n Return to \nprevious step";

	void OnGUI (){
		
		if(countCollect == 1){
			Destroy(GameObject.Find("wall"));
		}
		if(countCollect == 2){
			GUI.Box (new Rect (0, 0, 100, 25), "box1");
			GUI.Box (new Rect (0, 26, 100, 100), box1);
		}
		if(countCollect == 3){
			GUI.Box (new Rect (0, 0, 100, 25), "box1");
			GUI.Box (new Rect (0, 26, 100, 100), box1);
			GUI.Box (new Rect (100, 0, 100, 25), "box2");
			GUI.Box (new Rect (100, 26, 100, 100), box2);
		}
		if(countCollect == 4){
			GUI.Box (new Rect (0, 0, 100, 25), "box1");
			GUI.Box (new Rect (0, 26, 100, 100), box1);
			GUI.Box (new Rect (100, 0, 100, 25), "box2");
			GUI.Box (new Rect (100, 26, 100, 100), box2);
			GUI.Box (new Rect (200, 0, 100, 25), "box3");
			GUI.Box (new Rect (200, 26, 100, 100), box3);
			if(GUI.Button (new Rect (450, 75, 150, 30), "Return to the old lady")){
				Application.LoadLevel("scene5");
			}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	private bool isFiring = false;
	
	private IEnumerator WaitForDelay()
	{
	    yield return new WaitForSeconds(0.5f);
	    PlayerMesh.animation.Stop();
		isFiring = false;
	}
	
	private void DoAnimation(){
		
		ThirdPersonController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
		
			int stateCode = (int)controller._characterState;
			// Idle = 0 //Walking = 1 //Trotting = 2 //Running = 3 //Jumping = 4
			
			if (Input.GetKey (KeyCode.F)){
					isFiring = true;
			}else{
		
				if (controller.isMoving){
						PlayerMesh.animation.Play(WalkingAnimation.name);
				}else{
					
					if (stateCode == 4 ){
						PlayerMesh.animation.Play(JumpingAnimation.name);
					}else{
						PlayerMesh.animation.Stop();
					}
				}
			}
	}
	
	private void DoAttack(){
		
		Fire = Resources.Load("Fire", typeof(GameObject)) as GameObject;
		Instantiate(Fire, transform.position,Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
		
		CheckOtherDistance();
		CheckHealth();
		
		if (Input.GetKeyUp(KeyCode.F)){
				DoAttack();
		}
		
		if (isFiring){
			
			PlayerMesh.animation.Play(FireAnimation.name);
			StartCoroutine("WaitForDelay");
		}else{
			DoAnimation();
		}
		
	}
	
	private void CheckHealth(){
		
		if (Health <= 0){
		
			Health = 0;
			Application.LoadLevel("gameover");
		}
		
	}
	
	private void CheckLoot(){
		
		if (countCollect == 4){
			
			Debug.Log("good");
		}
	}
	
	private void CheckOtherDistance(){
	
	Collider[] targets = Physics.OverlapSphere (transform.position, 10.0f);
	
		foreach (Collider collided in targets){
			
		Vector3 objectPosition = collided.gameObject.transform.position;
		float distance = (Vector3.Distance(transform.position , objectPosition)) ; 	
			
			if (collided.gameObject.tag == "fireMob"){	
				
				if (distance < 1.5f){
					Destroy(collided.gameObject);
					Health -= 0.05;
					Debug.Log((int)Health);
				}
			}
			
			if (collided.gameObject.tag == "loot"){	
				
				if (distance < 2.0f){
					Debug.Log("Loot");
					if (Input.GetKeyUp(KeyCode.E)){
						//Loot
						Destroy(collided.gameObject);
						countCollect += 1;
					}
					
				}
			}
		}
		
	}
	
}
