using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAmmo : MonoBehaviour {
	public static int CurrentAmmo = 0;
	// Update is called once per frame
	public void UpdateAmmoCount(int value){
		CurrentAmmo += value;
		GetComponent<UnityEngine.UI.Text>().text = CurrentAmmo.ToString() + " / " + ARStats.ammoCount.ToString();
		if(CurrentAmmo == 0){
			GetComponent<UnityEngine.UI.Text>().color = new Color(255,0,0);
		}
	}
}
