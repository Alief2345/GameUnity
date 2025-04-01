using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class scorespacecraft : MonoBehaviour
{
    public int score = 0; // Current score
    public TextMeshProUGUI scoreText; // UI Text to display score

    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreDisplay();
    }

    // Method to update the score display
    public void UpdateScoreDisplay()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}