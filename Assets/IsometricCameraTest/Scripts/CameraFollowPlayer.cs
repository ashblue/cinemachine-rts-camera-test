using UnityEngine;

namespace CleverCrow.IsometricCameras {
    public class CameraFollowPlayer : MonoBehaviour {
        public Transform target;
        
        private void Update () {
            transform.position = target.position;
        }
    }
}
