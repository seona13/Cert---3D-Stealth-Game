using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAI : MonoBehaviour
{
	[SerializeField]
	private List<Transform> _waypoints;
	private NavMeshAgent _agent;
	[SerializeField]
	private int _currentTarget;
	private bool _reverse;
	private bool _targetReached;



	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		if (_agent == null)
		{
			Debug.LogError("Security Guard missing NavMeshAgent.");
		}
	}


	void Update()
	{
		if (_waypoints.Count > 0 && _waypoints[_currentTarget] != null)
		{
			_agent.SetDestination(_waypoints[_currentTarget].position);

			float distance = Vector3.Distance(transform.position, _waypoints[_currentTarget].position);

			if (distance < 1f && _targetReached == false)
			{
				_targetReached = true;

				StartCoroutine(WaitBeforeMoving());
			}
		}
	}


	IEnumerator WaitBeforeMoving()
	{
		if (_currentTarget == 0 || _currentTarget == _waypoints.Count - 1)
		{
			yield return new WaitForSeconds(Random.Range(2f, 5f));
		}
		else
		{
			yield return null;
		}

		if (_reverse)
		{
			_currentTarget--;

			if (_currentTarget < 0)
			{
				_reverse = false;
				_currentTarget++;
			}
		}
		else
		{
			_currentTarget++;

			if (_currentTarget == _waypoints.Count)
			{
				_reverse = true;
				_currentTarget--;
			}
		}

		_targetReached = false;
	}
}