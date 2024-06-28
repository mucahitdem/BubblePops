using UnityEngine;

public class TrajectoryVisualizer : MonoBehaviour
{
    [SerializeField]
    private float timeStep = 0.1f;

    [SerializeField]
    private int numPoints = 50;

    [SerializeField]
    private LayerMask collisionLayerMask;

    [SerializeField]
    private Transform ballStartPoint;
    
    private LineRenderer _lineRenderer;
    private TrajectoryCalculator _trajectoryCalculator;

    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _trajectoryCalculator = new TrajectoryCalculator(timeStep, numPoints, collisionLayerMask);
    }

    public void DrawTrajectory(Vector2 targetPosition)
    {
        Vector3[] points = _trajectoryCalculator.CalculateTrajectory(ballStartPoint.position, targetPosition);
        _lineRenderer.positionCount = points.Length;
        _lineRenderer.SetPositions(points);
    }
}