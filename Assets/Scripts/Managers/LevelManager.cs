using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private float timeToLoadNextScene = 5f;

    private void Awake()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex <= 0)
        {
            StartCoroutine(LoadFromSplash());
        }
    }

    private IEnumerator LoadFromSplash()
    {
        yield return new WaitForSeconds(timeToLoadNextScene);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
