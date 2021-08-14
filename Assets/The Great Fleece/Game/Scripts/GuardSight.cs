using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GuardSight : MonoBehaviour
{
	[SerializeField]
	private GameObject _cutscene;



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_cutscene.SetActive(true);
		}
	}
}