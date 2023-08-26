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
    public Transform lookTarget;
    public SoldierPooler soldierPooler;
    private List<Vector3> pathPoints = new List<Vector3>();
    [SerializeField] PlayerUpdateAIController playerAIController;

    [SerializeField] public int maxSoldierCount = 0; // Maximum number of soldiers

    public int currentSoldierCount = 0; // Current number of spawned soldiers

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        currentSoldierCount = 0;
        ClearPath();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClearPath();
        }

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, targetLayerMask))
            {
                playerAIController.canAimMove = false;

                Vector3 hit_info = hitInfo.point;
                hit_info.y = lineBoundY;

                if (DistanceToLastPoint(hit_info) > distanceToPoint)
                    DrawPath(hit_info);
            }
            else
            {
                playerAIController.canAimMove = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
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

        lineRenderer.positionCount = pathPoints.Count;
        lineRenderer.SetPositions(pathPoints.ToArray());
        playerAIController.canAimMove = false;
    }

    private void ClearPath()
    {
        pathPoints.Clear();
        lineRenderer.positionCount = 0;
       
    }

    private void SpawnSoldiersOnPath()
    {
        if (pathPoints.Count <= 1) return;

        for (int i = 0; i < pathPoints.Count - 1; i++)
        {
            Vector3 start = pathPoints[i];
            Vector3 end = pathPoints[i + 1];
            float distance = Vector3.Distance(start, end);

            int numberOfSoldiers = Mathf.CeilToInt(distance / offset);
            Vector3 direction = (end - start).normalized;

            for (int j = 0; j < numberOfSoldiers; j++)
            {
                if (currentSoldierCount >= maxSoldierCount)
                {
                    break;
                }

                Vector3 spawnPosition = start + direction * (j * (distance / numberOfSoldiers));
                GameObject soldier = soldierPooler.GetNew(spawnPosition);

                // Calculate rotation to look towards the target
                // ... (existing code)

                currentSoldierCount++;
            }
        }
    }
}
