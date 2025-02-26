using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingshotBall : MonoBehaviour
{
    public Rigidbody ballRigidbody; // Assign in inspector
    private Vector3 startPosition;
    private bool isDragging = false;
    private bool canDrag = true;
    public float orgX, orgY, orgZ;
    public bool reset;

    void Start()
    {
        startPosition = transform.position;
        orgX = transform.rotation.x;
        orgY = transform.rotation.y;
        orgZ = transform.rotation.z;
    }

    void Update()
    {
        if (reset)
        {
            ballRigidbody.isKinematic = true;
            transform.position = startPosition;
            transform.rotation = Quaternion.Euler(orgX, 90f, orgZ);
            ballRigidbody.isKinematic = false;
            canDrag = true;
            reset = false;
        }

        if (canDrag)
        {
            if (Input.GetMouseButtonDown(0))
            {

                isDragging = true;
                ballRigidbody.isKinematic = true; // Stop physics while dragging
            }

            if (isDragging)
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
                // Adjust the position calculation to ensure the ball moves correctly on your slingshot mechanic
                Vector3 direction = startPosition - mousePosition;
                float distance = direction.magnitude;
                Vector3 pullBackPosition = startPosition - direction.normalized * Mathf.Min(distance, 10f); // Limit pull back distance
                transform.position = pullBackPosition;
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                ReleaseBall();
            }
        }
        
    }
    

    private void ReleaseBall()
    {
        isDragging = false;
        canDrag = false;
        ballRigidbody.isKinematic = false;
        Vector3 launchDirection = startPosition - transform.position;
        ballRigidbody.AddForce(launchDirection * 1000); // Adjust force multiplier as needed
        Invoke("ResetBall", 5f); // Reset after 5 seconds for demonstration
    }

    private void ResetBall()
    {
        ballRigidbody.velocity = Vector3.zero; // Stop the ball
        ballRigidbody.angularVelocity = Vector3.zero; // Stop spinning
        transform.position = startPosition;
        ballRigidbody.isKinematic = true;
    }
}

