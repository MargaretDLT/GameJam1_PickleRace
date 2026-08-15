using UnityEngine;
using System.Collections;

public class ToastText : MonoBehaviour
{
    public GameObject slowText;
    public float textTime = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        slowText.SetActive(true);
        StartCoroutine(HideSlowText());
    }
   

    private IEnumerator HideSlowText()
    {
        yield return new WaitForSeconds(textTime);
        slowText.SetActive(false);
    }
}
