using UnityEngine;

namespace InputModule
{
    public class InputManager : MonoBehaviour
    {
        private Camera _mainCam;

        private void Awake()
        {
            _mainCam = Camera.main;
        }

        public Vector3 MousePos()
        {
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo))
            {
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
                return hitInfo.point;
            }

            return default;
        }
    }
}