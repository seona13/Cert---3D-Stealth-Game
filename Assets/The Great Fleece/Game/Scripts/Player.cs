using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
	[SerializeField]
	private GameObject _hitMarker;



	void Start()
	{

	}


	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out RaycastHit hitInfo))
			{
				Debug.Log("Hit at: (" + Input.mousePosition.x + ", " + Input.mousePosition.y + ", " + Input.mousePosition.z + ")");
				_hitMarker.transform.position = new Vector3(hitInfo.point.x, -2, hitInfo.point.z);
			}
		}
	}
}