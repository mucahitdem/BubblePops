using System.Collections.Generic;
using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace TrajectoryModule
{
    public class TrajectoryCalculator
    {
        private readonly LayerMask _collisionLayerMask;
        private readonly List<Vector3> _positions = new List<Vector3>();

        public TrajectoryCalculator(LayerMask collisionLayerMask)
        {
            _collisionLayerMask = collisionLayerMask;
        }

        public Vector3[] CalculateTrajectory(Vector3 startPosition, Vector3 targetPosition)
        {
            _positions.Clear();

            _positions.Add(startPosition);
            
            Vector3 direction = (targetPosition - startPosition).normalized;

            CalculateRecursiveTrajectory(startPosition, direction, 0);

            return _positions.ToArray();
        }

        private void CalculateRecursiveTrajectory(Vector3 startPoint, Vector3 direction, int currentDepth)
        {
            if (currentDepth > 10) // delete that
            {
                return;
            }

            direction.z = 0;
            startPoint.z = 0;

            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, Mathf.Infinity, _collisionLayerMask);


            if (hit.collider == null)
            {
                return;
            }

            _positions.Add(hit.point); // Add the hit point

            if (!hit.transform.TryGetComponent(out Cell cell))
            {
                Vector3 newDirection = Vector3.Reflect(direction, hit.normal);
                Vector3 newStartPoint = hit.point + (new Vector2(newDirection.x, newDirection.y)).normalized;
                CalculateRecursiveTrajectory(newStartPoint, newDirection, currentDepth + 1);
            }
        }
    }
}