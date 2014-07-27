using UnityEngine;
using System.Collections;

public class PlayerMove0: MonoBehaviour {

	public GameObject PlayerMesh;
	public AnimationClip WalkingAnimation;
	public AnimationClip JumpingAnimation;
	public AnimationClip FireAnimation;
	public GameObject InstatiateHere;
	private GameObject Fire;
	private double Health = 10;
	
	//private int countCollect = 0;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	//private bool isFiring = false;
	
	private IEnumerator WaitForDelay()
	{
	    yield return new WaitForSeconds(0.5f);
	    PlayerMesh.animation.Stop();
		//isFiring = false;
	}
	
	private void DoAnimation(){
		
		ThirdPersonController controller = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonController>();
		
			int stateCode = (int)controller._characterState;
			// Idle = 0 //Walking = 1 //Trotting = 2 //Running = 3 //Jumping = 4
			
			if (Input.GetKey (KeyCode.F)){
				//	isFiring = true;
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
	
	
	// Update is called once per frame
	void Update () {
		
		CheckOtherDistance();
		CheckHealth();
		
		
		//if (isFiring){
			
			//PlayerMesh.animation.Play(FireAnimation.name);
			//StartCoroutine("WaitForDelay");
		//}else{
			DoAnimation();
		//}
		
	}
	
	private void CheckHealth(){
		
		if (Health <= 0){
		
			Health = 0;
			Application.LoadLevel("scene4");
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
			
			
		}
		
	}
	
}
