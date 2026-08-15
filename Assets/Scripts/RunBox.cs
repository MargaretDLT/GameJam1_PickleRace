using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunBox : MonoBehaviour
{
    public ParticleSystem DeathParticle;
    AudioSource MyAudioSource;
    CameraShake cameraShake;
    public AudioClip soundFX;
    public int IndexSFX;
    public float speed = 2f;
    public GameObject burger;
    public bool isStopped = false;

    private void Start()
    {
        IndexSFX = SoundBoard.Instance.AddSoundEffect(soundFX);

        var camObj = GameObject.FindGameObjectWithTag("MainCamera");

        cameraShake = camObj.GetComponent<CameraShake>();
    }

    void Update()
    {
        if (isStopped) return;

        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // play deathbox sound
            SoundBoard.Instance.PlaySFX(IndexSFX);

            if (DeathParticle != null)
            {
                DeathParticle.Play();
            }

            //shake camera
            StartCoroutine(cameraShake.Shake(0.15f, 0.4f));
            Invoke("Reload", 2);  // wait 2 seconds, then reload level

            Transform player = other.transform.root;

            burger.transform.position = player.position;
            isStopped = true;
        }

    }

    void Reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public class MoveForward : MonoBehaviour
    {
        public float speed = 2f;

        void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
