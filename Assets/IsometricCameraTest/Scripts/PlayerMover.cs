using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;

namespace CleverCrow.IsometricCameras {
    public class PlayerMover : MonoBehaviour {
        public NavMeshAgent agent;
        public List<Transform> moveQueue = new List<Transform>();

        private int _moveIndex;

        private void Update () {
            if (agent.pathPending || agent.remainingDistance > agent.stoppingDistance) return;

            agent.SetDestination(GetNextPosition());
        }

        private Vector3 GetNextPosition () {
            return moveQueue[GetNextIndex()].position;
        }

        public int GetNextIndex () {
            var index = _moveIndex;
            _moveIndex++;

            if (index >= moveQueue.Count) {
                _moveIndex = index = 0;
            }
            
            return index;
        }
    }
}