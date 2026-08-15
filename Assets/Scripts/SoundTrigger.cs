using UnityEngine;

public class SoundTrigger : MonoBehaviour
{
    public AudioClip triggerSFX;
    private int sfxIndex;
    private void Start()
    {
        sfxIndex = SoundBoard.Instance.AddSoundEffect(triggerSFX);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        SoundBoard.Instance.PlaySFX(sfxIndex);
    }
}
