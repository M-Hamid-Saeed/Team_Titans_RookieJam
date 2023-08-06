using System.Collections.Generic;
using UnityEngine;

public class pathCreator : MonoBehaviour
{
    public GameObject soldierPrefab;
    public float offset = 1.0f; // Distance between soldiers on the path
    public LayerMask targetLayerMask;
    private LineRenderer lineRenderer;
    public float distanceToPoint;
    public float lineBoundY;
    public Transform towerPosition;
    private List<Vector3> pathPoints = new List<Vector3>();

    private void Awake()
    {

        lineRenderer = GetComponent<LineRenderer>();
        ClearPath();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClearPath();

        }
        // Check for touch or mouse input
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, targetLayerMask))
            {
                Vector3 hit_info = hitInfo.point;
                hit_info.y = lineBoundY;
                if (DistanceToLastPoint(hit_info) > distanceToPoint)

                    DrawPath(hit_info);
            }





        }
        else if (Input.GetMouseButtonUp(0))
        {
            // Spawn soldiers along the path when the player releases the touch/mouse
            SpawnSoldiersOnPath();

        }
    }
    private float DistanceToLastPoint(Vector3 hitpoint)
    {
        if (pathPoints.Count == 0)
            return Mathf.Infinity;
        return Vector3.Distance(pathPoints[pathPoints.Count - 1], hitpoint);
    }
    private void DrawPath(Vector3 point)
    {
        pathPoints.Add(point);

        // Update line renderer with the path points
        lineRenderer.positionCount = pathPoints.Count;

        lineRenderer.SetPositions(pathPoints.ToArray());
        Debug.Log("LINE DRAWWWW@");

    }

    private void ClearPath()
    {
        pathPoints.Clear();
        //lineRenderer.positionCount = 0;
    }

    private void SpawnSoldiersOnPath()
    {
        if (pathPoints.Count <= 1) return;

        Vector3 prevPoint = pathPoints[0];
        for (int i = 1; i < pathPoints.Count; i++)
        {
            Vector3 currentPoint = pathPoints[i];
            float distance = Vector3.Distance(prevPoint, currentPoint);

            int numberOfSoldiers = Mathf.FloorToInt(distance / offset);
            Vector3 direction = (currentPoint - prevPoint).normalized;

            Vector3 spawnPosition = prevPoint + direction;
            GameObject soldier = Instantiate(soldierPrefab, spawnPosition, Quaternion.identity);
           
            Vector3 lookAtDirection = (towerPosition.position - soldier.transform.position).normalized;
            float angle = Mathf.Atan2(lookAtDirection.y, lookAtDirection.x) * Mathf.Rad2Deg;

            
            soldier.transform.rotation = Quaternion.Euler(0f, angle,0f );

            // Optionally, you can also set the rotation
            // around the Y-axis to 0 (pitch) and the X-axis to 0 (roll)
            //soldier.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);

            prevPoint = currentPoint;
        }
    }
}
