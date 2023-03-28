using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    public void GamePlay()
    {
        StartCoroutine(LoadSceneTo("MenuLevels"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(.3f);
    }
}
