using UnityEngine;
using System.Collections;

public class Waypoint : MonoBehaviour {
	

public float savedTime;
public static float speed = 2.50f;
public bool loop_anim = true;
public bool loop_wayp = true;

public Transform[] waypoint;

public int currentWaypoint;

public Transform lookAtTargetWaypoint;

public bool destroyedRB = false;
	
public Vector3 PlayerPosition;
private bool enableAttack = false;
	
public static GameObject particle1;
public static GameObject particle2;
private GameObject fire1;
private GameObject fire2;
public GameObject InstantiateHere1;
public GameObject InstantiateHere2;
	
public int AIDamage = 1;
private float setY;
	
void Start()
	{
		setY = transform.position.y; 
		
	}
	
void Update()
	{ 
		transform.position= new Vector3(transform.position.x, setY,transform.position.z);
		transform.rotation = new Quaternion(0,transform.rotation.y,0,0);
		moveToWaypoint();
		PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
		
	}	


public void moveToWaypoint(){
		
		
Vector3 velocity = rigidbody.velocity;
if (currentWaypoint < waypoint.Length ){
	lookAtWaypoint();
	Vector3 target = waypoint[currentWaypoint].position;
	Vector3 moveDirection = target - transform.position;
	
			//for locationg player
			Vector3 playerPos = PlayerPosition;
			Vector3 diffToPlayer = playerPos - transform.position;	
			if (diffToPlayer.magnitude < 8)
			{
			velocity = diffToPlayer.normalized * speed;
			enableAttack = true;
				transform.LookAt (playerPos);
			}
			else
			{
				enableAttack = false;
				//Destroy(GameObject.FindGameObjectWithTag("AIFire").gameObject);//not working...
				if (moveDirection.magnitude < 3 ){
				currentWaypoint++;
				}else{
				velocity = moveDirection.normalized * speed;
				}
				transform.LookAt (lookAtTargetWaypoint);
			}
			
			
			
			
}else{
	if (loop_wayp){
	currentWaypoint = 0;
	}
	else{
	velocity = Vector3.zero;
	}


}


rigidbody.velocity = velocity;

}

	
void lookAtWaypoint(){
lookAtTargetWaypoint = waypoint[currentWaypoint].transform;
Vector3 lookPos = lookAtTargetWaypoint.position - transform.position;
lookPos.y = 0;
Quaternion rotation = Quaternion.LookRotation(lookPos);
transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5);
}	
	
}
