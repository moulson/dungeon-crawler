using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ARStats : MonoBehaviour {
	public static float spreadModifier = 0.0f;
	public static float damageModifier = 0.0f;
	public static float fireRateModifier = 0.0f;
	public static int ammoCount = 0;
	private string attachmentName;
	private bool hasBeenCalculated;

	void Update(){
		if(this.transform.childCount > 0 && !hasBeenCalculated){
			if(this.transform.GetChild(0).childCount > 0){
			CalculateStats();
			hasBeenCalculated = true;
			}
		}
	}

	void CalculateStats(){
		int totalChildren = transform.GetChild(0).childCount;
		Transform attachment;
		string theName = "";
		Attachment theAttachment;
		for(int i = 0; i < totalChildren; i++){
			attachment = transform.GetChild(0).GetChild(i);
			attachment.gameObject.layer = 9;
			theName = attachment.name.Replace("(Clone)", "");
			//find attachment in list
			theAttachment = ARAttachments.attachmentList.Find(x => x.Name == theName);
			spreadModifier += theAttachment.SpreadModifier;
			damageModifier += theAttachment.DamageModifier;
			fireRateModifier += theAttachment.FireRateModifier;
			ammoCount += theAttachment.AmmoCount;
		}
		Debug.Log("Fire Rate: " + fireRateModifier.ToString());
		Debug.Log("Damage: " + damageModifier.ToString());
		Debug.Log("Spread: " + spreadModifier.ToString());
		Debug.Log("Ammo Count: " + ammoCount.ToString());
		CalculateAmmo.CurrentAmmo = ammoCount;
	}
}
