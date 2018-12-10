using UnityEngine;
using UnityEngine.AI;

namespace CleverCrow.IsometricCameras {
    public class ProjectForwardPosition : MonoBehaviour {
        public NavMeshAgent agent;
        public Transform point;
        public float maxForwardDistance = 1;
        public float smoothTime = 1;
        public float maxSpeed = 1;

        private Vector3 damp;

        private void Update () {
            var heading = agent.destination - transform.position;
            var distance = heading.magnitude;
            var direction = heading / distance;
            
            // Works but there are a few problems
            // Turns are too harsh, needs to slowly follow the target point at turns
            // Dips in a way it shouldn't vertically
            
            // Ideas to fix
            
            
            var targetPos = transform.position + direction * maxForwardDistance;
            if (Vector3.Distance(transform.position, agent.destination) < maxForwardDistance) {
                targetPos = agent.destination;
            }
            
            point.transform.position = Vector3.SmoothDamp(point.transform.position, targetPos, ref damp, smoothTime, maxSpeed);
            
            
        }

        public void ClearDamp () {
            damp = Vector3.zero;
        }
    }
}