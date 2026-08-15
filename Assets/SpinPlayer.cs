using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinPlayer : MonoBehaviour
{
    [Header("Spin Settings")]
    public float spinSpeed = 720f;
    public float spinDuration = 0.5f;

    [Header("Knockback Settings")]
    public float knockbackForce = 5f;
    public float knockbackDuration = 0.5f;

    public AudioClip ketchupSFX;
    private int sfxIndex;
    private void Start()
    {
        sfxIndex = SoundBoard.Instance.AddSoundEffect(ketchupSFX);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CharacterController controller = other.GetComponent<CharacterController>();
        FancyPlayer playerScript = other.GetComponent<FancyPlayer>();

        if (controller == null || playerScript == null) return;

        Vector3 dir = (other.transform.position - transform.position).normalized;

        Transform visual = other.transform; // fallback spin target

        StartCoroutine(SpinAndPush(controller, playerScript, dir, visual));

        SoundBoard.Instance.PlaySFX(sfxIndex);
    }

    IEnumerator SpinAndPush(
         CharacterController controller,
         FancyPlayer playerScript,
         Vector3 dir,
         Transform visualModel)
    {
        float timer = 0f;
        float duration = Mathf.Max(spinDuration, knockbackDuration);

        playerScript.canRotate = false;

        while (timer < duration)
        {
            // spin player visuals
            visualModel.Rotate(0, spinSpeed * Time.deltaTime, 0);

            // knockback
            controller.Move(dir * knockbackForce * Time.deltaTime);

            timer += Time.deltaTime;
            yield return null;
        }

        playerScript.canRotate = true;
    }
}
