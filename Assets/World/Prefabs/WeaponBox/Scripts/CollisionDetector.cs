using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetector : MonoBehaviour {
	private bool inRange = false;
	private bool weaponSpawned = false;
	public AudioClip leverPullClip;
	public List<GameObject> theWeapons;
	public GameObject uiPrompt;
	private bool isShowing = true;
	private bool hasSpawnedUI = false;
	private bool hasDestroyedUI = false;
	void OnTriggerEnter(){
		if(!hasSpawnedUI){
			//Create the ui object, but only ever once.
			uiPrompt = Instantiate(uiPrompt);
			hasSpawnedUI = true;
		}
		if(isShowing && !hasDestroyedUI){
			//set state to in range, also activate the UI
			inRange = true;
			uiPrompt.SetActive(isShowing);
		}
	}
	void OnTriggerExit(){
		//when not looking/being near the object, make sure the UI isn't showing
		inRange = false;
		if(!hasDestroyedUI)
			uiPrompt.SetActive(false);
		
	}
	void Update(){
		if(Input.GetKeyDown(KeyCode.E) && inRange && !weaponSpawned){
			SpawnWeapon();
			isShowing = false;
			//Clean up this mess afterwards
			Destroy(uiPrompt,0.5f);
			hasDestroyedUI = true;
		}
	}
	void SpawnWeapon(){
		//Play the sound of rolling the machine.
		AudioSource.PlayClipAtPoint(leverPullClip, this.transform.position);
		//Create the weapon object.
		Instantiate(theWeapons[RandomNumber(0, theWeapons.ToArray().Length)], new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), this.transform.rotation);
		//Set the state to make sure machine won't be used again
		weaponSpawned = true;
	}
	int RandomNumber(int min, int max){
		System.Random randInt = new System.Random();
		try{
			return randInt.Next(min, max);
		}
		catch{
			//Failsafe in case of oob
			return randInt.Next(min, max - 1);
		}
	}
}
