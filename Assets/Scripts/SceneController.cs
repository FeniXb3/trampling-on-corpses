using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Animator fadePanel;

    public void NextLevel()
    {
        fadePanel.SetTrigger("SceneExit");
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
//        var asyncOperation = SceneManager.LoadSceneAsync(GetNextSceneBuildIndex());
//        asyncOperation.allowSceneActivation = false;
//
        yield return new WaitForSeconds(1f);
//
//        asyncOperation.allowSceneActivation = true;
        SceneManager.LoadScene(GetNextSceneBuildIndex());
    }

    private int GetNextSceneBuildIndex()
    {
        return SceneManager.GetActiveScene().buildIndex + 1;
    }
}