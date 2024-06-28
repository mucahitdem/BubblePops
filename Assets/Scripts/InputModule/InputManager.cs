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
                // Do something with hitInfo.point or hitInfo.collider
                Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
                return hitInfo.point;
            }

            // var rayDirection = _mainCam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -11));
            //
            // if (Physics.Raycast(_mainCam.transform.position, rayDirection, out _hit))
            // {
            //     return _hit.point;
            // }

            return default;
        }
    }
}