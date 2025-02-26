using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public Camera MainCamera, CinematicCamera;
    public float duration;
    bool allowCollision = true;

    private void OnTriggerEnter(Collider other)
    {
        Debug.LogError("Coll");
        if (allowCollision)
        {
            Debug.LogError("Collide");
            if (other.gameObject.CompareTag("BowlingBall"))
            {
                PlayCinematic();
            }
        }
    }

    void PlayCinematic()
    {
        allowCollision = false;
        MainCamera.gameObject.SetActive(false);
        CinematicCamera.gameObject.SetActive(true);
        StartCoroutine(Normalize());
    }
    IEnumerator Normalize()
    {
        yield return new WaitForSeconds(duration);
        MainCamera.gameObject.SetActive(true);
        CinematicCamera.gameObject.SetActive(false);
        allowCollision = true;
    }
}
