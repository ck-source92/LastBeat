using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMenu : MonoBehaviour
{
    [SerializeField] GameObject popUpTextTutorial;
    public void GamePlay()
    {
        if (PlayerPrefs.GetInt("isFinishTutorial") == 0)
        {
            popUpTextTutorial.SetActive(true);
        }
        else
        {
            StartCoroutine(LoadSceneTo("MenuLevels"));
        }
    }
    public void TutorialScene()
    {
        FindObjectOfType<AudioMainMenu>().ResetAudioMainMenu();
        Loader.Load(Loader.Scene.Tutorial);
        Loader.SceneSelected = Loader.Scene.Tutorial;
    }
    public void TutorialYes()
    {
        popUpTextTutorial.SetActive(false);
    }
    IEnumerator LoadSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(.3f);
    }
}
