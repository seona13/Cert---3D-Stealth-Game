using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCamSight : MonoBehaviour
{
	[SerializeField]
	private GameObject _cutscene;



	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			other.gameObject.SetActive(false);
			_cutscene.SetActive(true);
		}
	}
}