using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }
    
    public BowlingPin[] pins; // Assign in the Unity Inspector
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component that displays the score
    private int totalScore = 0;

    void Awake()
    {
        // Singleton pattern to ensure only one GameManager instance
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    // Call this method to update the score when a pin is knocked down
    public void UpdateScore()
    {
        int pinsKnockedDown = CountPinsKnockedDown();
        totalScore += pinsKnockedDown;
        scoreText.text = "Score: " + totalScore.ToString();
    }

    // Helper method to count the number of pins knocked down
    private int CountPinsKnockedDown()
    {
        int count = 0;
        foreach (BowlingPin pin in pins)
        {
            if (pin.isKnockedDown)
            {
                count++;
                pin.isKnockedDown = false; // Reset the pin for the next frame
            }
        }
        return count;
    }
}

