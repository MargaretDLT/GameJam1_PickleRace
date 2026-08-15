using UnityEngine;
using System.Collections;

public class StartText : MonoBehaviour
{
    public GameObject startText;
    public float displayTime = 3f;

    private void Start()
    {
        startText.SetActive(true);
        StartCoroutine(HideText());
    }

    private IEnumerator HideText()
    {
        yield return new WaitForSeconds(displayTime);
        startText.SetActive(false);
    }
}
