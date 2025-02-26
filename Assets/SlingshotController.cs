using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlingshotController : MonoBehaviour
{
    public RectTransform slingshotBase; // Assign in inspector
    public RectTransform pullbackIndicator; // Assign in inspector
    public Rigidbody ballRigidbody; // Assign in inspector
    private Vector2 originalPosition;

    void Start()
    {
        originalPosition = pullbackIndicator.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // This function is called when dragging starts
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Convert screen point to UI space
        RectTransformUtility.ScreenPointToLocalPointInRectangle(slingshotBase, eventData.position, eventData.pressEventCamera, out var localPoint);

        // Set the position of the pullback indicator within bounds
        pullbackIndicator.anchoredPosition = Vector2.ClampMagnitude(localPoint, 100); // Limit drag distance
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Apply force to the ball when drag ends based on the distance pulled back
        Vector3 forceDirection = (originalPosition - pullbackIndicator.anchoredPosition) * 10; // Adjust force multiplier as needed
        ballRigidbody.AddForce(new Vector3(forceDirection.x, 0, forceDirection.y), ForceMode.Impulse);

        // Reset the pullback indicator's position
        pullbackIndicator.anchoredPosition = originalPosition;
    }
}
