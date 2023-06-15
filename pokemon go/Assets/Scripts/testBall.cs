using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testBall : MonoBehaviour
{
    public GameObject ballPrefab;
    public float throwForce = 10f;
    public float curveMultiplier = 1f;

    private Camera mainCamera;
    private bool isDragging = false;
    private Vector3 initialTouchPosition;
    private Vector3 currentTouchPosition;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // Record initial touch position
                    initialTouchPosition = touch.position;
                    isDragging = true;
                    break;

                case TouchPhase.Moved:
                    // Record current touch position
                    currentTouchPosition = touch.position;
                    break;

                case TouchPhase.Ended:
                    // Calculate throw direction and force
                    if (isDragging)
                    {
                        Vector3 throwDirection = (currentTouchPosition - initialTouchPosition).normalized;
                        float throwDistance = Vector3.Distance(currentTouchPosition, initialTouchPosition);
                        float throwForceWithCurve = throwDistance * throwForce * curveMultiplier;

                        // Instantiate the ball prefab
                        GameObject ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);
                        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();

                        // Apply the throw force to the ball
                        ballRigidbody.AddForce(throwDirection * throwForceWithCurve, ForceMode.Impulse);
                    }

                    // Reset dragging state
                    isDragging = false;
                    break;
            }
        }
    }
}
