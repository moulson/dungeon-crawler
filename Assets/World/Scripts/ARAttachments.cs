using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attachment{
	public string Name;
	public float DamageModifier;
	public float SpreadModifier;
	public float FireRateModifier;
	public int AmmoCount;
}

public class ARAttachments : MonoBehaviour {
	public static List<Attachment> attachmentList = new List<Attachment>();

	void Start(){
		//Initialize all attachments


		//Initialize stocks
		Attachment stock001 = new Attachment(){
			Name = "stock001",
			DamageModifier = 0.0f,
			SpreadModifier = 0.5f,
			FireRateModifier = 0.0f,
			AmmoCount = 0};
		attachmentList.Add(stock001);

		//Initialize grips
		Attachment grip001 = new Attachment(){
			Name = "grip001",
			DamageModifier = 0.0f,
			SpreadModifier = 1.0f,
			FireRateModifier = 0.0f,
			AmmoCount = 0};
		attachmentList.Add(grip001);
		
		//Initialize fire modes
		Attachment DebugFireMode = new Attachment(){
			Name = "DebugFireMode",
			DamageModifier = 0.0f,
			SpreadModifier = 0f,
			FireRateModifier = 0.3f,
			AmmoCount = 0};
		attachmentList.Add(DebugFireMode);
		
		//Initialize fuel cells
		Attachment magazine_asval = new Attachment(){
			Name = "magazine_asval",
			DamageModifier = 0.0f,
			SpreadModifier = -0.2f,
			FireRateModifier = 0.0f,
			AmmoCount = 30};
		attachmentList.Add(magazine_asval);

		//Initialize underbarrels
		Attachment underbarrel001 = new Attachment(){
			Name = "underbarrel001",
			DamageModifier = 0.0f,
			SpreadModifier = 0.0f,
			FireRateModifier = 0.0f,
			AmmoCount = 0};
		attachmentList.Add(underbarrel001);

		//Initialize barrels
		Attachment barrel001 = new Attachment(){
			Name = "barrel001",
			DamageModifier = 0.1f,
			SpreadModifier = 0.5f,
			FireRateModifier = 0.2f,
			AmmoCount = 0};
		attachmentList.Add(barrel001);


		//Initialize optics
		Attachment fivefivetwo = new Attachment(){
			Name = "552",
			DamageModifier = 0.0f,
			SpreadModifier = 1.0f,
			FireRateModifier = 0.2f,
			AmmoCount = 0};
		attachmentList.Add(fivefivetwo);
		Attachment optic002 = new Attachment(){
			Name = "optic002",
			DamageModifier = 1.0f,
			SpreadModifier = 4.0f,
			FireRateModifier = -0.6f,
			AmmoCount = 0};
		attachmentList.Add(optic002);
	}
}
