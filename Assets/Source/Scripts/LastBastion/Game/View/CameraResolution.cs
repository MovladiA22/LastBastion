using UnityEngine;

namespace LastBastion.Game.View
{
    public class CameraResolution : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private void Start()
        {
            _camera.aspect = (float)Screen.width / Screen.height;
        }
    }
}
