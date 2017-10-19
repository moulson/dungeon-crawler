using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {
	private bool inRange = false;
	private bool weaponSpawned = false;
	public AudioClip leverPullClip;
	public List<GameObject> theWeapons;
	void OnTriggerEnter(){
		inRange = true;
	}
	void OnTriggerExit(){
		inRange = false;
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && inRange && !weaponSpawned){
			SpawnWeapon();
		}
	}
	void SpawnWeapon(){
		AudioSource.PlayClipAtPoint(leverPullClip, this.transform.position);
		Instantiate(theWeapons[RandomNumber(0, theWeapons.ToArray().Length)], new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), this.transform.rotation);
		weaponSpawned = true;
	}
	int RandomNumber(int min, int max){
		System.Random randInt = new System.Random();
		try{
			return randInt.Next(min, max);
		}
		catch{
			return randInt.Next(min, max - 1);
		}
	}
}
