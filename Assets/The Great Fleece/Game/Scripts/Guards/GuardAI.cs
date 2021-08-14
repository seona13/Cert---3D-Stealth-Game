using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class GuardAI : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Animator _anim;
	[SerializeField]
	private List<Transform> _waypoints;
	[SerializeField]
	private int _currentTarget;
	private bool _reverse;
	private bool _targetReached;
	private bool _coinTossed;
	private Vector3 _coinPos;



	void OnEnable()
	{
		Player.onCoinTossed += MoveToCoin;
	}


	void OnDisable()
	{
		Player.onCoinTossed -= MoveToCoin;
	}


	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		if (_agent == null)
		{
			Debug.LogError("Security Guard missing NavMeshAgent.");
		}

		_anim = GetComponent<Animator>();
		if (_anim == null)
		{
			Debug.LogError("Security Guard missing Animator");
		}
	}


	void Update()
	{
		if (_coinTossed == false && _waypoints.Count > 0 && _waypoints[_currentTarget] != null)
		{
			_agent.SetDestination(_waypoints[_currentTarget].position);

			float distance = Vector3.Distance(transform.position, _waypoints[_currentTarget].position);

			if (distance < 1f && (_currentTarget == 0 || _currentTarget == _waypoints.Count - 1))
			{
				_anim.SetBool("isWalking", false);
			}
			else
			{
				_anim.SetBool("isWalking", true);
			}

			if (distance < 1f && _targetReached == false)
			{
				_targetReached = true;

				if (_waypoints.Count > 1)
				{
					StartCoroutine(WaitBeforeMoving());
				}
			}
		}
		else if (_coinTossed == true)
		{
			float distance = Vector3.Distance(transform.position, _coinPos);

			if (distance < 4f)
			{
				_anim.SetBool("isWalking", false);
			}
			else
			{
				_anim.SetBool("isWalking", true);
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


	void MoveToCoin(Vector3 coinPos)
	{
		_agent.SetDestination(coinPos);
		_agent.stoppingDistance = 4f;
		_coinTossed = true;
		_coinPos = coinPos;
	}
}