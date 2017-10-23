using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindEnemies : MonoBehaviour {

	public float radius;
	private bool hasEnemies = false;
	private int totalEnemies = 0;

	void FixedUpdate () {
		if(!hasEnemies){
			Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(radius, radius, radius));
			foreach(Collider col in hitColliders){
				if(col.transform.tag == "Enemy"){
					col.transform.parent = transform;
					totalEnemies++;
					hasEnemies = true;
				}
			}
		}
	}

	void UpdateEnemies(string s){
		if(s == "death"){
			totalEnemies--;
			Debug.Log("Enemy killed. " + totalEnemies + " enemies left.");
		}
		if(totalEnemies == 0){
			transform.parent.Find("DoorControl").SendMessage("RoomCleared");
		}
	}
}
