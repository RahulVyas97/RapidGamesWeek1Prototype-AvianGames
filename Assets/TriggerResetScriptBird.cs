using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TriggerResetScriptBird : MonoBehaviour
{
    public GameObject[] pins;
    public GameObject bowlingBall;
    public float score;
    public TextMeshProUGUI ScoreText;
    // Start is called before the first frame update
    void Start()
    {
        pins = GameObject.FindGameObjectsWithTag("BowlingPins");
        UpdateScore();
    }
    public void UpdateScore()
    {
        ScoreText.text = "Score:  " + score.ToString();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag=="BowlingBall")
        {
            Invoke("ResetPins", 4f);
        }
    }
    
    void ResetPins()
    {
        foreach(GameObject pin in pins)
        {
            pin.GetComponent<BowlingPin>().reset=true;
            Debug.Log("ArrayTest");
        }

        bowlingBall.GetComponent<SlingshotBall>().reset=true;
    }
}
