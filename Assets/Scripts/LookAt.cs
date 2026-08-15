using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class LookAt : MonoBehaviour
{
	public bool bLookAt;	// set to true to look at player

	GameObject Player;      // holds player reference
	Vector3 lookPosition;		// player's XZ and enemy's Y

    // Start is called before the first frame update
    void Start()
    {
		Player = GameObject.FindGameObjectWithTag("Player");	// find player reference
    }

    // Update is called once per frame
    void Update()
    {
		// if the game object should face player
		if (bLookAt)
		{
			// construct a position to look at that won't tip (uses the enemy's Y)
			lookPosition = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
			// look at player object
			transform.LookAt(lookPosition, Vector3.up);
		}
    }
}
