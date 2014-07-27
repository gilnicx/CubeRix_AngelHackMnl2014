using UnityEngine;
using System.Collections;

public class MobStats : MonoBehaviour {
	
	private bool isFiring = false;
	public int Health = 10;
	
	public bool isBoss = false;
	
	private Vector3 _myAngle;
	private GameObject Fire;
	// Use this for initialization
	void Start () {
	 _myAngle = this.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
	
		CheckOtherDistance();
		CheckHealth();
		 
	}
	
	private void CheckHealth(){
		
		if (Health <= 0){
			
			Destroy(this.gameObject);
			
		}
		
	}
	
	
	private void DoAttack(){
		
		if (isBoss){
			Fire = Resources.Load("FireMobBoss", typeof(GameObject)) as GameObject;
		}else{
			Fire = Resources.Load("FireMob", typeof(GameObject)) as GameObject;
		}
		
		Instantiate(Fire, transform.position,Quaternion.identity);
	}
		
	private void CheckOtherDistance(){
	
	Collider[] targets = Physics.OverlapSphere (transform.position, 10.0f);
		
		foreach (Collider collided in targets){
				
		Vector3 objectPosition = collided.gameObject.transform.position;
		float distance = (Vector3.Distance(transform.position , objectPosition)) ; 	
		
			if (collided.gameObject.tag == "fire"){	
				
				if (distance < 1.5f){
					Destroy(collided.gameObject);
					Health -= 1;
				}
			}
			
			if (collided.gameObject.tag == "Player"){	
				
				transform.LookAt(collided.gameObject.transform);
				DoAttack();
				switch ( this.gameObject.name ){
				case "Mob_A" :FireMobMovement.target = GameObject.Find("targetA");
					break;
				case "Mob_B" :FireMobMovement.target = GameObject.Find("targetB");
					break;
				case "Mob_C" :FireMobMovement.target = GameObject.Find("targetC");
					Debug.Log("C");
					break;
				default : FireMobMovement.target =null;
					break;
				}
				
			}else{
				//transform.eulerAngles = _myAngle;
			}
		
			
		}
		
	}
	
}
