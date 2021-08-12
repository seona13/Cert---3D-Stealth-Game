using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Player : MonoBehaviour
{
	private NavMeshAgent _agent;



	void Start()
	{
		_agent = GetComponent<NavMeshAgent>();
		if (_agent == null)
		{
			Debug.LogError("Player missing NavMeshAgent.");
		}
	}


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				//Debug.Log("Hit at: (" + Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z + ")");
				_agent.SetDestination(hitInfo.point);
			}
		}
	}
}