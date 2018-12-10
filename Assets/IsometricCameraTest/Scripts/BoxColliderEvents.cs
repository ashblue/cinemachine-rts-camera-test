using UnityEngine;
using UnityEngine.Events;

namespace CleverCrow.IsometricCameras {
    [RequireComponent(typeof(BoxCollider))]
    public class BoxColliderEvents : MonoBehaviour {
        public UnityEvent onEnter;
        public UnityEvent onExit;
        
        private void OnTriggerEnter (Collider other) {
            Debug.Log(other.gameObject);
            if (!other.CompareTag("Player")) return;
            
            onEnter.Invoke();
        }

        private void OnTriggerExit (Collider other) {
            if (!other.CompareTag("Player")) return;

            onExit.Invoke();
        }
    }
}
