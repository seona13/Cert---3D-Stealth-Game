using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VoiceOverTrigger : MonoBehaviour
{
	[SerializeField]
	private AudioClip _clip;



	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position);
		}
	}
}