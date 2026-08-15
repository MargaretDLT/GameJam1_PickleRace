using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class KnifeSoundTrigger : MonoBehaviour
{
    public AudioClip KnifeSFX;
    private int sfxIndex;
    public GameObject knifeText;
    public float textTime = 2f;
    private void Start()
    {
        sfxIndex = SoundBoard.Instance.AddSoundEffect(KnifeSFX);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SoundBoard.Instance.StartLoopingSFX(sfxIndex);

        knifeText.SetActive(true);
        StartCoroutine(HideSlowText());
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SoundBoard.Instance.StopLoopingSFX();
        }
    }
    private IEnumerator HideSlowText()
    {
        yield return new WaitForSeconds(textTime);
        knifeText.SetActive(false);
    }
}
