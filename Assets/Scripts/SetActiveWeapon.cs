using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveWeapon : MonoBehaviour {

	// Use this for initialization
	public GameObject meleeSlot;
	public GameObject arSlot;
	public GameObject pistolSlot;
	public GameObject launcherSlot;
	public GameObject heavySlot;
	private bool firstSwitch = true;
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Alpha1) && meleeSlot.transform.childCount > 0){
			meleeSlot.SetActive(true);
			arSlot.SetActive(false);
			pistolSlot.SetActive(false);
			launcherSlot.SetActive(false);
			heavySlot.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha2) && arSlot.transform.childCount > 0){
			meleeSlot.SetActive(false);
			arSlot.SetActive(true);
			pistolSlot.SetActive(false);
			launcherSlot.SetActive(false);
			heavySlot.SetActive(false);
			StartCoroutine(UpdateAmmo("ar"));
		}
		if(Input.GetKeyDown(KeyCode.Alpha3) && pistolSlot.transform.childCount > 0){
			meleeSlot.SetActive(false);
			arSlot.SetActive(false);
			pistolSlot.SetActive(true);
			launcherSlot.SetActive(false);
			heavySlot.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha4) && launcherSlot.transform.childCount > 0){
			meleeSlot.SetActive(false);
			arSlot.SetActive(false);
			pistolSlot.SetActive(false);
			launcherSlot.SetActive(true);
			heavySlot.SetActive(false);
		}
		if(Input.GetKeyDown(KeyCode.Alpha5) && heavySlot.transform.childCount > 0){
			meleeSlot.SetActive(false);
			arSlot.SetActive(false);
			pistolSlot.SetActive(false);
			launcherSlot.SetActive(false);
			heavySlot.SetActive(true);
		}
	}

	IEnumerator UpdateAmmo(string s){
		yield return new WaitForSeconds(0.1f);
		if(firstSwitch){
			firstSwitch = false;
			GameObject.Find("AmmoCount").SendMessage("UpdateAmmoCount", ARStats.ammoCount);
			GameObject.Find("AmmoCount").SendMessage("UpdateAmmoCount", -ARStats.ammoCount);
		}
		else{
			//why won't 0 just work :(
			GameObject.Find("AmmoCount").SendMessage("UpdateAmmoCount", 1);
			GameObject.Find("AmmoCount").SendMessage("UpdateAmmoCount", -1);
		}
	}
}
