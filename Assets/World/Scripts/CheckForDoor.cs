using UnityEngine;
using System.Collections;

public class CheckForDoor : MonoBehaviour {
	public GameObject theRoom;
	public GameObject theDoor;
	public GameObject theWall;
	public int roomSize = 50;
    //public int isWall = 1;
	// Use this for initialization
	void Start () {
        //make some vectors
		float numToAdd = (roomSize / 2) + 10;
        float radius = 5f;
        Vector3 quartZ = new Vector3(0, 90, 0);
        Vector3 quartX = new Vector3(0, 0, 0);
        GameObject negX, posX, negZ, posZ;
        Vector3 posXCheck = new Vector3(theRoom.transform.position.x + numToAdd, 0, theRoom.transform.position.z);
        Vector3 negXCheck = new Vector3(theRoom.transform.position.x - numToAdd, 0, theRoom.transform.position.z);
        Vector3 posZCheck = new Vector3(theRoom.transform.position.x, 0, theRoom.transform.position.z + numToAdd);
        Vector3 negZCheck = new Vector3(theRoom.transform.position.x, 0, theRoom.transform.position.z - numToAdd);
        //Check if we should put a door or wall at PosX
        if(Physics.CheckSphere(posXCheck, radius))
        {
            posX = (GameObject)Instantiate(theDoor);
			posX.transform.position = new Vector3(theRoom.transform.position.x + (roomSize/3), 10, theRoom.transform.position.z);
            posX.transform.Rotate(quartX);
        }
        else
        {
            posX = (GameObject)Instantiate(theWall);
			posX.transform.position = new Vector3(theRoom.transform.position.x + (roomSize/3), 10, theRoom.transform.position.z);
            posX.transform.Rotate(quartX);
        }
        //Check if we should put a door or wall at PosZ
        if (Physics.CheckSphere(posZCheck, radius))
        {
            posZ = (GameObject)Instantiate(theDoor);
			posZ.transform.position = new Vector3(theRoom.transform.position.x, 10, theRoom.transform.position.z + (roomSize/3));
            posZ.transform.Rotate(quartZ.x, quartZ.y + 180, quartZ.z);
        }
        else
        {
            posZ = (GameObject)Instantiate(theWall);
			posZ.transform.position = new Vector3(theRoom.transform.position.x, 10, theRoom.transform.position.z + (roomSize/3));
            posZ.transform.Rotate(quartZ);
        }
        //Check if we should put a door or wall at NegX
        if (Physics.CheckSphere(negXCheck, radius))
        {
            negX = (GameObject)Instantiate(theDoor);
			negX.transform.position = new Vector3(theRoom.transform.position.x - (roomSize/3), 10, theRoom.transform.position.z);
            negX.transform.Rotate(quartX.x, quartX.y + 180, quartX.z);
        }
        else
        {
            negX = (GameObject)Instantiate(theWall);
			negX.transform.position = new Vector3(theRoom.transform.position.x - (roomSize / 3), 10, theRoom.transform.position.z);
            negX.transform.Rotate(quartX);
        }
        //Check if we should put a door or wall at NegZ
        if (Physics.CheckSphere(negZCheck, radius))
        {
            negZ = (GameObject)Instantiate(theDoor);
			negZ.transform.position = new Vector3(theRoom.transform.position.x, 10, theRoom.transform.position.z - (roomSize / 3));
            negZ.transform.Rotate(quartZ);
        }
        else
        {
            negZ = (GameObject)Instantiate(theWall);
			negZ.transform.position = new Vector3(theRoom.transform.position.x, 10, theRoom.transform.position.z - (roomSize / 3));
            negZ.transform.Rotate(quartZ);
        }
    }	// Update is called once per frame
	void Update () {
	}
}
