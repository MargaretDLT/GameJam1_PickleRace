using UnityEngine;

// Copyright © 2024 Randy Angle
// Permission is granted to use this script in your student, private, or commercial game projects, provided this notice remains intact
// Commerical release means putting "Additional code by Rangle Angle" in the game credits.

// Updates the Score readout display once every 1-second
// attach to a Legacy TextMesh object for HUD or Shop
// if the lag is too much at 1-second, shorten to 0.5 or 0.25 second
public class Score : MonoBehaviour
{
    public int ScoreAmount;
    TextMesh ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreAmount = PlayerPrefs.GetInt("PrefsScore");
        ScoreText = GetComponent<TextMesh>();
        ScoreText.text = "Score: " + ScoreAmount.ToString();
        InvokeRepeating("ScoreUpdate", 1.0f, 1.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke();
    }

    // Update is called once per second
    void ScoreUpdate()
    {
        ScoreAmount = PlayerPrefs.GetInt("PrefsScore");
        ScoreText.text = "Score: " + ScoreAmount.ToString();
    }
}
