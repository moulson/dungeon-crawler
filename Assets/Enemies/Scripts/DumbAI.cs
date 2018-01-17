using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DumbAI : MonoBehaviour {
	//Make sure it only activates when player is in the room
	private GameObject thePlayer;
	public int maxDist = 10;
	private bool isActive = false;
	public float speed = 10f;
	private Vector3 inverseDir, relativePos;

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
	}

	float DistanceToPlayer(Vector3 pos){
		return Vector3.Distance(thePlayer.transform.position, pos);
	}

	void OutOfBounds(){
		relativePos = new Vector3(thePlayer.transform.position.x - transform.position.x, 0, thePlayer.transform.position.z - transform.position.z);
		transform.Translate( -10 * (relativePos.normalized) * speed * Time.deltaTime);
	}
	void DoAttack(){

	}

	void Djikstra(){
		
	}
}
