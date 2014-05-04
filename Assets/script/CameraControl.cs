using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPosition = target.position;
		targetPosition.z = -1;
		transform.position = targetPosition;
	}


}
