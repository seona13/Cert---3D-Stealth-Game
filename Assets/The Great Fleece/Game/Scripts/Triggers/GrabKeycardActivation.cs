using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GrabKeycardActivation : MonoBehaviour
{
	[SerializeField]
	private GameObject _cutscene;



	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_cutscene.SetActive(true);
			GameManager.Instance.HasCard = true;
			Collider collider = GetComponent<Collider>();
			if (collider != null)
			{
				collider.enabled = false;
			}
		}
	}
}