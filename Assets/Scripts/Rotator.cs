using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class Rotator : MonoBehaviour {

    Transform[] weapons;
    float rotateSpeed = 100f;

	void Start () {
        weapons = new Transform[transform.childCount];
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i] = transform.GetChild(i);
        }
	}
	
	void Update () {
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].Rotate(Vector3.up * Time.deltaTime * rotateSpeed, Space.World);
        }
	}
}
