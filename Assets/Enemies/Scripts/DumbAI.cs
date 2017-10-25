using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour {
	//Make sure it only activates when player is in the room
	private GameObject thePlayer;
	public int maxDist = 10;
	private bool isActive = false;
	public float speed = 10f;
	private Vector3 inverseDir;
	private Vector3 boundary1, boundary2, boundary3, boundary4;

	void Update(){
		if(isActive){
			if(DistanceToPlayer(transform.position) > maxDist + 5){
				transform.position = Vector3.MoveTowards(
					transform.position, thePlayer.transform.position, speed * Time.deltaTime
					);
			}
			else if(DistanceToPlayer(transform.position) < maxDist - 5){
				//make sure it's not trying to go oob...
				inverseDir = new Vector3(thePlayer.transform.position.x - transform.position.x, 0, thePlayer.transform.position.z - transform.position.z);
				transform.Translate((-1 * (inverseDir).normalized) * speed * Time.deltaTime);
			}
			else{
				//Move around a bit...
			}
			DoAttack();
		}
	}

	void ActivateAI(){
		//Find the player
		thePlayer = GameObject.FindGameObjectWithTag("Player");
		isActive = true;
		GetBoundaries();
	}

	float DistanceToPlayer(Vector3 pos){
		return Vector3.Distance(thePlayer.transform.position, pos);
	}

	void GetBoundaries(){
		Vector3 pos = transform.parent.position;
		boundary1 = new Vector3(pos.x - 5, pos.y, pos.z - 5);
		boundary2 = new Vector3(pos.x - 5, pos.y, pos.z);
		boundary3 = new Vector3(pos.x + 5, pos.y, pos.z -5);
		boundary4 = new Vector3(pos.x + 5, pos.y, pos.z + 5);  
	}
	void OutOfBounds(){
		//move back into the playable zone

		//If player is on the right, go left and vice versa
	}
	void DoAttack(){

	}
}
