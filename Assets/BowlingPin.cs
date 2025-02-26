using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class BowlingPin : MonoBehaviour
{
    public int pinValue = 1; // Assign a value to each pin (for scoring purposes)
    public bool isKnockedDown = false;
    private Rigidbody pinRigidbody;
    public Vector3 startPosition;
    public float orgX, orgY, orgZ;
    public bool reset;
    public GameObject scoreCount;
    public bool hasLocation;

    // Define a reference to the GameManager or scoring system if needed
    // public GameManager gameManager;
    private void Start()
    {
        // Get the Rigidbody component of the pin
        pinRigidbody = GetComponent<Rigidbody>();
       
      
    }

    

    private void Update()
    {
        if (!hasLocation)
        {
            hasLocation = true;
            Invoke("GetLocation", .1f);
        }
        if (reset)
        {
            if(transform.position != startPosition) 
            {
                scoreCount.GetComponent<TriggerResetScriptBird>().score += 1;
                scoreCount.GetComponent<TriggerResetScriptBird>().UpdateScore();
            }
            pinRigidbody.isKinematic = true;
            transform.position = startPosition;
            transform.rotation=Quaternion.Euler(orgX, orgY, orgZ);
            pinRigidbody.isKinematic =false;
            Debug.Log("ResetTest");
            reset = false;
        }
    }
    public bool IsKnockedDown() // Public method to access the state
    {
        return isKnockedDown;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BowlingBall") && !isKnockedDown)
        {
            // Mark the pin as knocked down
            isKnockedDown = true;
            //scoreCount.GetComponent<TriggerResetScriptBird>().score += 1;
            // Apply a force to the pin to simulate it being knocked down
            // Adjust the force values as needed for your game
            Vector3 forceDirection = -transform.forward; // You might need to adjust this direction based on the orientation of your pins
            float forceMagnitude = 10f; // Adjust the magnitude of the force
            pinRigidbody.AddForce(forceDirection * forceMagnitude, ForceMode.Impulse);

            // Update the score using the pin's value
            // gameManager.UpdateScore(pinValue);

            // Play sound or add visual effects for pin falling if desired
            // Add your code here

            // Check for game over or other conditions if needed
            // gameManager.CheckGameStatus();
        }
    }

    void GetLocation()
    {
        startPosition = transform.position;// pins save the start position
        orgX = transform.rotation.x;
        orgY = transform.rotation.y;
        orgZ = transform.rotation.z;
    }
    
}
