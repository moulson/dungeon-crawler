using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour {
	private RaycastHit hit;
	private List<Transform> ownedDoors = new List<Transform>();
	public bool negXHit = false, negZHit = false, posXHit = false, posZHit = false;
	private bool waitingToAnimate = false;
	private Collider fakePlayer;
	void FixedUpdate(){
		//Make the door controller take ownership of the doors it should control
		if(!posXHit){
			if(Physics.Raycast(transform.position, new Vector3(90,0,0),out hit ,100)){
				posXHit = true;
				//Do things with the collider
				try{
					if(hit.collider.transform.parent.tag == "Doorway")
						hit.collider.transform.parent.parent = transform;
					else
						hit.collider.transform.parent = transform;
				}catch{
					hit.collider.transform.parent = transform;
				}
			}
		}
		if(!negXHit){
			if(Physics.Raycast(transform.position, new Vector3(-90,0,0),out hit ,100)){
				negXHit = true;
				try{
					if(hit.collider.transform.parent.tag == "Doorway")
						hit.collider.transform.parent.parent = transform;
					else
						hit.collider.transform.parent = transform;
				}catch{
					hit.collider.transform.parent = transform;
				}
			}
		}
		if(!negZHit){
			if(Physics.Raycast(transform.position, new Vector3(0,0,-90),out hit ,100)){
				negZHit = true;
				try{
					if(hit.collider.transform.parent.tag == "Doorway")
						hit.collider.transform.parent.parent = transform;
					else
						hit.collider.transform.parent = transform;
				}catch{
					hit.collider.transform.parent = transform;
				}
			}
		}
		if(!posZHit){
			if(Physics.Raycast(transform.position, new Vector3(0,0,90),out hit ,100)){
				posZHit = true;
				try{
					if(hit.collider.transform.parent.tag == "Doorway")
						hit.collider.transform.parent.parent = transform;
					else
						hit.collider.transform.parent = transform;
				}catch{
					hit.collider.transform.parent = transform;
				}
			}
		}
		if(waitingToAnimate){
			OnTriggerEnter(fakePlayer);
		}
	}

	void OnTriggerEnter(Collider col){
		if(col.transform.tag == "Player Pickup Trigger"){
			fakePlayer = col;
			if(posXHit && posZHit && negXHit && negZHit){
				RoomEntered();
			}
			else{
				waitingToAnimate = true;
			}	
			

		}
	}
	void RoomCleared(){
		//Open doors
		Debug.Log("Cleared the room!");
		foreach(Transform door in ownedDoors){
			door.Find("TheDoor").Translate(new Vector3(0, -18, 0));
		}
	}
	void RoomEntered(){
		//Close doors
		waitingToAnimate = false;
		for(int i = 0; i < transform.childCount; i++){
			
			if(transform.GetChild(i).name.Contains("DoorPrefab")){
				ownedDoors.Add(transform.GetChild(i));
			}
		}
		foreach(Transform door in ownedDoors){
			Debug.Log(door.Find("TheDoor"));
			door.Find("TheDoor").Translate(new Vector3(0, 18, 0));
			//door.Find("TheDoor").GetComponent<Animation>().Play("DoorClose");
		}
	}
}
