using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class CameraFollow : MonoBehaviour
{
	[Tooltip("Who to follow - Player")]
	public Transform target;
	[Tooltip("Speed to move camera - 5")]
	public float camera_speed;
	[Tooltip("Offset of camera from target - 0,3,-5")]
	public Vector3 camera_offset;

	protected Transform trans;
		
	void Awake()
	{
		trans = GetComponent<Transform>();
		target = GameObject.FindGameObjectWithTag("Player").transform;
		trans.position = target.position + camera_offset;
		trans.LookAt(target);
	}

	void Update()
	{
		//trans.LookAt (target);
		if (target == null)
		{
			target = GameObject.FindGameObjectWithTag("Player").transform;
		}
		trans.position = Vector3.Lerp(trans.position, target.position + camera_offset, camera_speed * Time.deltaTime);
	}
}
