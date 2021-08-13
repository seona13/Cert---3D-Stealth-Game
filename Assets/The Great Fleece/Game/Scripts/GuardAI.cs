using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAI : MonoBehaviour
{
	[SerializeField]
	private List<Transform> _waypoints;
	private Transform _currentTarget;
	private NavMeshAgent _agent;



	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		if (_agent == null)
		{
			Debug.LogError("Security Guard missing NavMeshAgent.");
		}

		if (_waypoints.Count > 0 && _waypoints[0] != null)
		{
			_currentTarget = _waypoints[0];
		}
	}


	void Update()
	{
		if (_currentTarget != null)
		{
			float distance = Vector3.Distance(transform.position, _currentTarget.position);

			if (distance > 1f)
			{
				_agent.SetDestination(_currentTarget.position);
			}
		}
	}
}