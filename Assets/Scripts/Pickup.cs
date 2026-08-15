using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class Pickup : MonoBehaviour
{
	public GameObject shockwavePrefab;
	public int pickupScore = 1;     // set value in inspector
	public AudioClip soundFX;
	public int IndexSFX;

	AudioSource MyAudioSource;

	private void Start()
	{
		IndexSFX = SoundBoard.Instance.AddSoundEffect(soundFX);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			// play pickup sound
			SoundBoard.Instance.PlaySFX(IndexSFX);

			// add score
			int Score = PlayerPrefs.GetInt("PrefsScore") + pickupScore;
			PlayerPrefs.SetInt("PrefsScore", Score);
			PlayerPrefs.Save();
			Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
			Destroy(gameObject);
		}
	}
}

