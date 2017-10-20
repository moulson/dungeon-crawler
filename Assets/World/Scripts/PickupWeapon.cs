using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupWeapon : MonoBehaviour {

	public GameObject uiPrompt;
	
	private bool hasBeenUsed = false;
	private bool canBePicked = false;
	private bool hasBeenPicked = false;
	private bool needsInstantiating = true;
	public GameObject assaultRifleSlot;
	
	void OnTriggerEnter(){
		//Make sure that the weapon box has been used first
		if(this.transform.childCount > 0){
			if(needsInstantiating)
				uiPrompt = Instantiate(uiPrompt);
				needsInstantiating = false;
			canBePicked = true;
			uiPrompt.SetActive(true);
		}
	}
	void OnTriggerExit(){
		canBePicked = false;
		//Disable ui prompt
		if(!needsInstantiating && !hasBeenPicked)
			uiPrompt.SetActive(false);
	}

	void Update(){
		if(needsInstantiating && this.transform.childCount > 0){
			OnTriggerEnter();
		}
		if(Input.GetKeyDown(KeyCode.E) && canBePicked){
			AddToInventory();
		}
	}

	void AddToInventory(){
		this.transform.parent = assaultRifleSlot.transform;
		this.transform.position = assaultRifleSlot.transform.position;
		this.transform.rotation = assaultRifleSlot.transform.rotation;
		hasBeenPicked = true;
		Destroy(uiPrompt);
	}
}
