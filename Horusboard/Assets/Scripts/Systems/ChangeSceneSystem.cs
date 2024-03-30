using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneSystem : MonoBehaviour
{

    public void LoadScene(int buildIndex)
    {
        StartCoroutine(LoadingScene(buildIndex));
    }

    IEnumerator LoadingScene(int buildIndex)
    {
        SceneManager.LoadSceneAsync(buildIndex);

        yield return null;
    }
}
