﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager.Instance.AddListener(EventType.ChangeLevel, OnChangeLevel);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener(EventType.ChangeLevel, OnChangeLevel);
    }

    private void OnChangeLevel(object arg)
    {
        var sceneName = arg as string;
        if(!string.IsNullOrEmpty(sceneName))
        {
            NextLevel(sceneName);
        }
    }

    public void NextLevel(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }

    private IEnumerator LoadScene(string sceneName)
    {
//        var asyncOperation = SceneManager.LoadSceneAsync(GetNextSceneBuildIndex());
//        asyncOperation.allowSceneActivation = false;
//
        yield return new WaitForSeconds(1f);
//
//        asyncOperation.allowSceneActivation = true;
        SceneManager.LoadScene(sceneName);
    }
}