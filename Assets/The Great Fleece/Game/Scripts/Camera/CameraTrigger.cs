using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraTrigger : MonoBehaviour
{
	[SerializeField]
	private Transform _cameraPosition;


	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			Camera.main.transform.position = _cameraPosition.position;
			Camera.main.transform.rotation = _cameraPosition.rotation;
		}
	}
}