using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
	private static AudioManager _instance;
	public static AudioManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("AudioManager is missing.");
			}
			return _instance;
		}
	}

	[SerializeField]
	public AudioSource _voiceOver;



	void Awake()
	{
		_instance = this;
	}


	public void PlayVoiceOver(AudioClip clipToPlay)
	{
		_voiceOver.clip = clipToPlay;
		_voiceOver.Play();
	}
}