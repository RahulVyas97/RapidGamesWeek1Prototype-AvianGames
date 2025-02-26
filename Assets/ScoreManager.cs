 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public BowlingPin[] pins; // Assign all pins in the inspector
    public TextMeshProUGUI scoreText; // Assign a UI Text to display the score
    private int score = 0;

    void Update()
    {
        // Optional: Trigger score update based on a specific event, e.g., when the ball stops moving
    }

    public void CalculateScore()
    {
        int knockedDownPins = 0;
        foreach (BowlingPin pin in pins)
        {
            // Assuming each pin has a way to determine if it's knocked down (e.g., checking its rotation)
            if (pin.transform.eulerAngles.x > 10 || pin.transform.eulerAngles.z > 10) // Example condition
            {
                knockedDownPins++;
            }
        }
        // Update the score based on knockedDownPins; adjust the scoring logic as necessary
        score = knockedDownPins; // Simple scoring, 1 point per pin
        scoreText.text = "Score: " + score;
    }

    // Call this method to reset the score and pins at the start of a new frame or game
    public void ResetGame()
    {
        score = 0;
        scoreText.text = "Score: " + score;
        // Reset pins to their upright position if necessary
    }
}

