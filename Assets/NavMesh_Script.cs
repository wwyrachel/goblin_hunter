using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMesh_Script : MonoBehaviour {
    [SerializeField]
    Transform _destination;

    NavMeshAgent _navMeshAgent;

	// Use this for initialization
	void Start () {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        SetDestination();
        
	}

    // Update is called once per frame
    public void SetDestination() {
        if (_navMeshAgent != null) {
            Vector3 targetVector = _destination.transform.position;
            _navMeshAgent.SetDestination(targetVector);
        }
    }
}
