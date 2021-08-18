using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	public static GameManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("GameManager is null.");
			}
			return _instance;
		}
	}

	[SerializeField]
	private PlayableDirector _introCutscene;
	public bool HasCard { get; set; }



	void Awake()
	{
		_instance = this;
	}


	void Update()
	{
		if (Input.GetKeyDown(KeyCode.S))
		{
			_introCutscene.time = 60f;
		}
	}
}