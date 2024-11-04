using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelExit : MonoBehaviour
{


    [SerializeField] float levelLoadDelay = 1f;


    private void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(nameof(LoadNextScene),levelLoadDelay);
    }

    IEnumerator LoadNextScene()
    {
        yield return new WaitForSecondsRealtime(levelLoadDelay);

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        FindObjectOfType<ScenePersistence>().ResetScenePersist();

        SceneManager.LoadScene(nextSceneIndex);
    }


}
