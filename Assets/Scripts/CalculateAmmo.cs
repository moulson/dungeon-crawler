using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAmmo : MonoBehaviour {
	public static int CurrentAmmo = 0;
	// Update is called once per frame
	public void UpdateAmmoCount(int value){
		Debug.Log("Chagning ammo by: " + value);
		CurrentAmmo += value;
		GetComponent<UnityEngine.UI.Text>().text = "Ammo: " + CurrentAmmo.ToString();
		if(CurrentAmmo == 0){
			GetComponent<UnityEngine.UI.Text>().color = new Color(255,0,0);
		}
	}
}
