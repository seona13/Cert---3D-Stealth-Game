using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadManager : MonoBehaviour
{
	[SerializeField]
	private Image _progressBar;
	private WaitForEndOfFrame pause = new WaitForEndOfFrame();



	void Start()
	{
		StartCoroutine(LoadLevelAsync());
	}


	IEnumerator LoadLevelAsync()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync("Main");

		while (operation.isDone == false)
		{
			_progressBar.fillAmount = operation.progress;
			yield return pause;
		}
	}
}