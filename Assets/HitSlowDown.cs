using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSlowDown : MonoBehaviour
{
    public float slowMultiplier = 0.4f;
    public float slowDuration = 2f;
    public AudioClip slowSFX;
    private int sfxIndex;
    public GameObject slowText;
    public float textTime = 2f;
    private void Start()
    {
        sfxIndex = SoundBoard.Instance.AddSoundEffect(slowSFX);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        FancyPlayer player = other.GetComponentInParent<FancyPlayer>();
        if (player == null) return;

        SoundBoard.Instance.StopSFX();
        SoundBoard.Instance.PlaySFX(sfxIndex);

        player.ApplySlow(slowMultiplier, slowDuration);
        
        //for text
        slowText.SetActive(true);
        StartCoroutine(HideSlowText());
    }

    private IEnumerator HideSlowText()
    {
        yield return new WaitForSeconds(textTime);
        slowText.SetActive(false);
    }
}
