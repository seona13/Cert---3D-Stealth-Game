using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
	private NavMeshAgent _agent;
	private Animator _anim;
	private Vector3 _destination;
	[SerializeField]
	private GameObject _coinPrefab;
	private bool _coinAvailable = true;



	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		if (_agent == null)
		{
			Debug.LogError("Player missing NavMeshAgent.");
		}

		_anim = GetComponentInChildren<Animator>();
		if (_anim == null)
		{
			Debug.LogError("Player missing Animator on model.");
		}
	}


	void Update()
	{
		MovePlayer();

		if (Input.GetMouseButtonDown(1) && _coinAvailable)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				GameObject coin = Instantiate(_coinPrefab);
				coin.transform.position = new Vector3(hitInfo.point.x, -1.8f, hitInfo.point.z);
				_coinAvailable = false;
			}
		}
	}


	void MovePlayer()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				//Debug.Log("Hit at: (" + Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z + ")");
				_destination = hitInfo.point;
				_agent.SetDestination(_destination);
				_anim.SetBool("isWalking", true);
			}
		}

		float distance = Vector3.Distance(transform.position, _destination);

		if (distance < 1.0f)
		{
			_anim.SetBool("isWalking", false);
		}
	}
}