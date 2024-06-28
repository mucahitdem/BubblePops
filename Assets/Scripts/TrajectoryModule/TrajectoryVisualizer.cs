using UnityEngine;

namespace TrajectoryModule
{
    public class TrajectoryVisualizer : MonoBehaviour
    {
        [SerializeField]
        private LayerMask collisionLayerMask;

        [SerializeField]
        private Transform ballStartPoint;
    
        private LineRenderer _lineRenderer;
        private TrajectoryCalculator _trajectoryCalculator;

        private void Start()
        {
            _lineRenderer = GetComponent<LineRenderer>();
            _trajectoryCalculator = new TrajectoryCalculator(collisionLayerMask);
        }


        public void DisableTrajectory()
        {
            _lineRenderer.enabled = false;
        }
        public void DrawTrajectory(Vector2 targetPosition)
        {
            _lineRenderer.enabled = true;

            Vector3[] points = _trajectoryCalculator.CalculateTrajectory(ballStartPoint.position, targetPosition);
            _lineRenderer.positionCount = points.Length;
            _lineRenderer.SetPositions(points);
        }
    }
}