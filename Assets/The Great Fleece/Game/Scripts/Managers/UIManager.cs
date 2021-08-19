using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
	private static UIManager _instance;
	public static UIManager Instance
	{
		get
		{
			if (_instance == null)
			{
				Debug.LogError("UIManager is missing.");
			}
			return _instance;
		}
	}



	void Awake()
	{
		_instance = this;
	}


	public void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}


	public void QuitGame()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
	}
}