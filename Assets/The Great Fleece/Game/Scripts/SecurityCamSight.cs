using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SecurityCamSight : MonoBehaviour
{
	private Animator _anim;
	private MeshRenderer _renderer;
	[SerializeField]
	private GameObject _cutscene;



	private void Start()
	{
		_anim = GetComponentInParent<Animator>();
		if (_anim == null)
		{
			Debug.LogError("Security Camera missing Animator.");
		}

		_renderer = GetComponent<MeshRenderer>();
		if (_renderer == null)
		{
			Debug.LogError("Security Camera Cone missing Mesh Renderer");
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			_anim.enabled = false;
			_renderer.material.SetColor("_TintColor", new Color(0.98f, 0.34f, 0.4f, 0.03f));
			StartCoroutine(PauseCamera());
		}
	}


	IEnumerator PauseCamera()
	{
		yield return new WaitForSeconds(0.5f);
		_cutscene.SetActive(true);
	}
}