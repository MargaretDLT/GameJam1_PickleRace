using System;
using UnityEngine;
using UnityEngine.SceneManagement;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class DeathBox : MonoBehaviour
{
	public ParticleSystem DeathParticle;
	AudioSource MyAudioSource;
	CameraShake cameraShake;
	public AudioClip soundFX;
	public int IndexSFX;
    public GameObject burgerPrefab;
    public GameObject currentBurger;
    private bool isDead = false;

    private void Start()
	{
        IndexSFX = SoundBoard.Instance.AddSoundEffect(soundFX);

        Camera cam = Camera.main;

        cameraShake = cam.GetComponent<CameraShake>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (isDead) return;
        if (!other.CompareTag("Player")) return;

        isDead = true;

        GetComponent<Collider>().enabled = false;

        SoundBoard.Instance.PlaySFX(IndexSFX);

        if (DeathParticle != null)
            DeathParticle.Play();

        StartCoroutine(cameraShake.Shake(0.15f, 0.4f));

        Transform player = other.transform.root;
        Vector3 spawnPos = player.position - player.forward * 2f;

        //stop player movement 
        FancyPlayer playerMove = other.GetComponentInParent<FancyPlayer>();
        if (playerMove != null)
        {
            playerMove.enabled = false;
        }

        Rigidbody rb = other.GetComponentInParent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        // destroy old burger (SAFE way)
        if (currentBurger != null)
        {
            Destroy(currentBurger);
        }

        // spawn and store new burger
        currentBurger = Instantiate(burgerPrefab, spawnPos, Quaternion.identity);

        Invoke(nameof(Reload), 2f);
    }



    void Reload()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
