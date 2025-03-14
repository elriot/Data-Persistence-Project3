using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using TMPro;


[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
	public TMP_InputField userName;
	public TMP_Text BestScoreText;

	void Start()
	{
		// userName = GameObject.Find("NameInput").GetComponent<InputField>();
		ScoreManager.Instance.LoadScore();
		BestScoreText.text = "Best Score : " + ScoreManager.Instance.BestScoreUserName + " : " + ScoreManager.Instance.BestScore;
	}
	public void StartGame()
	{
		// Debug.Log("start : " + userName.text);
		ScoreManager.Instance.SetCurrentUserName(userName.text);
		SceneManager.LoadScene(1);
	}


	public void ExitGame()
	{
		ScoreManager.Instance.SaveScore();
#if UNITY_EDITOR
		EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
	}
}
