using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CalculateAmmo : MonoBehaviour {
	public static int CurrentAmmo = 0;
	// Update is called once per frame
	public void UpdateAmmoCount(int value){
		CurrentAmmo += value;
		GetComponent<UnityEngine.UI.Text>().text = CurrentAmmo.ToString();
	}
}
