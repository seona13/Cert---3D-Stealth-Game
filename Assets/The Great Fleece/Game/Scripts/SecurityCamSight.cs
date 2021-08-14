using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCamSight : MonoBehaviour
{
	private Animator _anim;
	[SerializeField]
	private GameObject _cutscene;



	private void Start()
	{
		_anim = GetComponentInParent<Animator>();
		if (_anim == null)
		{
			Debug.LogError("Security Camera missing Animator.");
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_anim.enabled = false;
			StartCoroutine(PauseCamera());
		}
	}


	IEnumerator PauseCamera()
	{
		yield return new WaitForSeconds(0.5f);
		_cutscene.SetActive(true);
	}
}