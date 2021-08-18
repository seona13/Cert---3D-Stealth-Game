using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinStateActivation : MonoBehaviour
{
	[SerializeField]
	private GameObject _cutscene;



	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (GameManager.Instance.HasCard)
			{
				_cutscene.SetActive(true);
			}
			else
			{
				Debug.Log("Darren needs to pick up the keycard!");
			}
		}
	}
}