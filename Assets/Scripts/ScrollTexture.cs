using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class ScrollTexture : MonoBehaviour
{
	public float ScrollU = 0.5f;
	public float ScrollV = 0.5f;

    // Update is called once per frame
    void Update()
    {
		GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * ScrollU, Time.time * ScrollV);
    }
}
