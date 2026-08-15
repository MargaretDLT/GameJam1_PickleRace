using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

public class Goal : MonoBehaviour
{
    public float reloadDelay = 3f;   

    public GameObject shockwavePrefab;
    public AudioClip MySFX;
    int AudioIndex;
    public TMP_Text winnerText;

private void Start()
    {
        AudioIndex = SoundBoard.Instance.AddSoundEffect(MySFX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            SoundBoard.Instance.PlaySFX(AudioIndex);

            winnerText.text = "Winner!";
            winnerText.gameObject.SetActive(true);

            Instantiate(shockwavePrefab, Vector3.up * 2f, Quaternion.identity);
            StartCoroutine(ReloadAfterDelay());
        }

        GameObject shockwave = Instantiate(shockwavePrefab, transform.position, Quaternion.identity);
    }

    IEnumerator ReloadAfterDelay()
    {
        yield return new WaitForSeconds(reloadDelay);
        SceneManager.LoadScene(0);
    }
}
