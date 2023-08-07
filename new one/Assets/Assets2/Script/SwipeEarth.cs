using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothDragEarth : MonoBehaviour
{
    private Vector3 touchStartPos;
    private Vector3 previousTouchPos;
    private Vector3 rotationAxis = new Vector3(0, 0, 1); // Z-axis rotation
    private Quaternion initialRotation;

    [SerializeField] private float dragSpeed = 5f;

    private void Start()
    {
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    OnTouchBegin(touch.position);
                    break;
                case TouchPhase.Moved:
                    OnTouchMove(touch.position);
                    break;
                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    OnTouchEnd();
                    break;
            }
        }
    }

    private void OnTouchBegin(Vector2 touchPosition)
    {
        touchStartPos = touchPosition;
        previousTouchPos = touchPosition;
    }

    private void OnTouchMove(Vector2 touchPosition)
    {
        Vector2 touchDelta = touchStartPos - previousTouchPos;
        float rotationAmount = -touchDelta.x * dragSpeed * Time.deltaTime;

        Quaternion rotationDelta = Quaternion.AngleAxis(rotationAmount, rotationAxis);
        transform.rotation = rotationDelta * transform.rotation;

        previousTouchPos = touchPosition;
    }

    private void OnTouchEnd()
    {
        // Implement any necessary cleanup or actions after the drag ends
    }
}