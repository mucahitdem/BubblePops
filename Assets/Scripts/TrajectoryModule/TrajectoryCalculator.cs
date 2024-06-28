using UnityEngine;

public class TrajectoryCalculator
{
    private readonly float _timeStep;
    private readonly int _maxPoints;
    private readonly LayerMask _collisionLayerMask;

    public TrajectoryCalculator(float timeStep, int maxPoints, LayerMask collisionLayerMask)
    {
        _timeStep = timeStep;
        _maxPoints = maxPoints;
        _collisionLayerMask = collisionLayerMask;
    }

    public Vector3[] CalculateTrajectory(Vector2 startPosition, Vector2 targetPosition)
    {
        Vector3[] points = new Vector3[_maxPoints];
        points[0] = startPosition;

        Vector2 currentPosition = startPosition;
        Vector2 initialVelocity = (targetPosition - startPosition).normalized * CalculateLaunchVelocity(startPosition, targetPosition);
        Vector2 currentVelocity = initialVelocity;

        for (int i = 1; i < _maxPoints; i++)
        {
            Vector2 nextPosition = currentPosition + currentVelocity * _timeStep + Physics2D.gravity * (0.5f * _timeStep * _timeStep);
            RaycastHit2D hit = Physics2D.Linecast(currentPosition, nextPosition, _collisionLayerMask);

            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Ball"))
                {
                    break;
                }

                Vector2 reflectVelocity = Vector2.Reflect(currentVelocity, hit.normal);
                Vector2 reflectPoint = hit.point;
                
                // Adjust nextPosition after reflection
                nextPosition = reflectPoint + reflectVelocity * _timeStep + Physics2D.gravity * (0.5f * _timeStep * _timeStep);

                // Update current velocity
                currentVelocity = reflectVelocity;
            }

            points[i] = nextPosition;
            currentPosition = nextPosition;
        }

        return points;
    }

    private float CalculateLaunchVelocity(Vector2 startPosition, Vector2 targetPosition)
    {
        // Calculate a suitable launch velocity based on the distance between start and target
        float distance = Vector2.Distance(startPosition, targetPosition);
        // You can tweak this calculation based on your game's requirements
        return distance * 2.0f; // Example: You might want to adjust this factor
    }
}
