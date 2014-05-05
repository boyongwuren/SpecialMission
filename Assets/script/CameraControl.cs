using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public Transform target;

	public float minx = 0;

	public float maxx = 0;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 targetPosition = target.position;
		targetPosition.z = -10;
		targetPosition.y += 0.8f;
		if(targetPosition.x < minx)
		{
			targetPosition.x = minx;
		}

		if(targetPosition.x > maxx)
		{
			targetPosition.x = maxx;
		}

		transform.position = targetPosition;

	}


}
