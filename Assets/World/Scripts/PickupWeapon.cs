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

    public static string AmmoType;
	void ActivateUI(){
		//Make sure that the weapon box has been used first
		if(this.transform.childCount > 0){
			if(needsInstantiating)
				uiPrompt = Instantiate(uiPrompt);
				needsInstantiating = false;
			canBePicked = true;
			if(!hasBeenPicked)
				uiPrompt.SetActive(true);
			}
	}
    void OnTriggerEnter(Collider hit){
		if(hit.gameObject.tag == "Activator")
			ActivateUI();	
	}
	void OnTriggerExit(){
		canBePicked = false;
		//Disable ui prompt
		if(!needsInstantiating && !hasBeenPicked)
			uiPrompt.SetActive(false);
	}

	void Update(){
		if(needsInstantiating && this.transform.childCount > 0){
			ActivateUI();
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

	void SetAmmoType(string theammo){
		AmmoType =  theammo;
	}
}
