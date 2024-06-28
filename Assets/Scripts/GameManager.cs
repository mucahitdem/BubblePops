using InputModule;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputManager _inputManager;
    private TrajectoryVisualizer _trajectoryVisualizer;

    private void Start()
    {
        _inputManager = ServiceLocator.Instance.GetService<InputManager>();
        _trajectoryVisualizer = ServiceLocator.Instance.GetService<TrajectoryVisualizer>();
    }


    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            var hitPoint = _inputManager.MousePos();
            if (hitPoint == default)
                return;
            
            _trajectoryVisualizer.DrawTrajectory(hitPoint);
        }
    }
}