using UnityEngine;
using UnityEngine.InputSystem;

// Copyright © 2026 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class SimplePlayer : MonoBehaviour
{
    public float playerSpeed = 2.0f;
    public float rotateSpeed = 90.0f;
    public float jumpHeight = 1.0f;

    public AudioClip JumpSFX;
    public int IndexSFX;

    private CharacterController playerController;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        IndexSFX = SoundBoard.Instance.AddSoundEffect(JumpSFX);

        playerController = GetComponent<CharacterController>();
        playerVelocity = new Vector3(0, 0, 0);
    }

    void Update()
    {
		// Rotate around y-axis based on input, A & D keys
		float horizontal;
		if (Keyboard.current.aKey.isPressed)
		{
			horizontal = -1.0f * rotateSpeed * Time.deltaTime;
		}
		else
		{
			if (Keyboard.current.dKey.isPressed)
			{
				horizontal = 1.0f * rotateSpeed * Time.deltaTime;
			}
			else
			{
				horizontal = 0.0f;
			}
		}
		transform.Rotate(0, horizontal, 0);

		// set forward/backward movement based on input, W & S keys
		float vertical;
		if (Keyboard.current.wKey.isPressed)
		{
			vertical = 1.0f * playerSpeed;
		}
		else
		{
			if (Keyboard.current.sKey.isPressed)
			{
                vertical = -1.0f * playerSpeed;
			}
			else
			{
				vertical = 0.0f;
			}
		}
		Vector3 moveVector = new Vector3(0, 0, vertical);

		// detect if the player is on the ground and zero Y-axis
		groundedPlayer = playerController.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // calculate the Y-axis based on jumping and gravity
        if (Keyboard.current.spaceKey.isPressed && groundedPlayer)
        {
            // play jump sound
            SoundBoard.Instance.PlaySFX(IndexSFX);

            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue); // instant impulse when jump pressed
        }
        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        playerVelocity.y += gravityValue * Time.deltaTime;
        
        // adjust player movement in Y-axis
        moveVector.y = playerVelocity.y;

        // actually move the player
        moveVector = transform.rotation * moveVector; // multiply by rotation for orientation
        playerController.Move(moveVector * Time.deltaTime);
    }
}