using UnityEngine;

public class LineElectric : MonoBehaviour
{
    public int numberOfPoints = 100;
    public float lineLength = 10f;
    public float raycastDistance = 1f;

    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = numberOfPoints;
    }

    private void Update()
    {
        Vector3 startPoint = transform.position;
        Vector3 endPoint = transform.position + transform.forward * lineLength;
        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(numberOfPoints - 1, endPoint);

        float segmentLength = lineLength / (numberOfPoints - 1);

        for (int i = 1; i < numberOfPoints - 1; i++)
        {
            Vector3 pointPosition = startPoint + transform.forward * (i * segmentLength);

            RaycastHit hitLeft;
            RaycastHit hitRight;

            // Perform raycasts to check for collisions on the left and right sides.
            if (Physics.Raycast(pointPosition, -transform.right, out hitLeft, raycastDistance))
            {
               if(hitLeft.collider.tag == "Enemy")
                {
                    Destroy(hitLeft.collider.gameObject);
                }
            }
            else if (Physics.Raycast(pointPosition, transform.right, out hitRight, raycastDistance))
            {
                pointPosition = hitRight.point;


                if (hitRight.collider.tag == "Enemy")
                {
                    Destroy(hitRight.collider.gameObject);
                }
            }

            lineRenderer.SetPosition(i, pointPosition);
        }
    }


   
}
