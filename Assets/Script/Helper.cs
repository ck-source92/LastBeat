using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    public static GameObject Find(string search)
    {
        var scene = SceneManager.GetActiveScene();
        var sceneRoots = scene.GetRootGameObjects();

        GameObject result = null;
        foreach (var root in sceneRoots)
        {
            if (root.name.Equals(search) || root.tag.Equals(search)) return root;

            result = FindRecursive(root, search);

            if (result) break;
        }

        return result;
    }

    public static GameObject Find(string search, bool isActive)
    {
        var scene = SceneManager.GetActiveScene();
        var sceneRoots = scene.GetRootGameObjects();

        GameObject result = null;
        foreach (var root in sceneRoots)
        {
            if (root.name.Equals(search) || root.tag.Equals(search) && (root.activeInHierarchy == isActive)) return root;

            result = FindRecursive(root, search, isActive);

            if (result) break;
        }

        return result;
    }

    private static GameObject FindRecursive(GameObject obj, string search)
    {
        GameObject result = null;
        foreach (Transform child in obj.transform)
        {
            if (child.name.Equals(search) || child.tag.Equals(search)) return child.gameObject;

            result = FindRecursive(child.gameObject, search);

            if (result) break;
        }

        return result;
    }
    private static GameObject FindRecursive(GameObject obj, string search, bool isActive)
    {
        GameObject result = null;
        foreach (Transform child in obj.transform)
        {
            if (child.name.Equals(search) || child.tag.Equals(search) && ((child.gameObject.activeInHierarchy == isActive))) return child.gameObject;

            result = FindRecursive(child.gameObject, search, isActive);

            if (result) break;
        }

        return result;
    }

    public static List<GameObject> GetChildren(GameObject go)
    {
        List<GameObject> list = new List<GameObject>();
        return GetChildrenHelper(go, list);
    }

    private static List<GameObject> GetChildrenHelper(GameObject go, List<GameObject> list)
    {
        if (go == null || go.transform.childCount == 0)
        {
            return list;
        }
        foreach (Transform t in go.transform)
        {
            list.Add(t.gameObject);
        }
        return list;
    }

    public static GameObject FindDontDestroyOnLoadObjects(string search)
    {
        GameObject temp = null;
        try
        {
            temp = new GameObject();
            Object.DontDestroyOnLoad(temp);
            UnityEngine.SceneManagement.Scene dontDestroyOnLoad = temp.scene;
            Object.DestroyImmediate(temp);
            temp = null;

            var objects = dontDestroyOnLoad.GetRootGameObjects();
            GameObject found = null;
            foreach (var item in objects)
            {
                if (item.name.Equals(search) || item.tag.Equals(search))
                {
                    found = item;
                }
            }
            return found;
        }
        finally
        {
            if (temp != null)
                Object.DestroyImmediate(temp);
        }
    }

    public static bool AnimatorIsPlaying(Animator animator)
    {
        return animator.GetCurrentAnimatorStateInfo(0).length >
               animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    public static bool AnimatorIsPlaying(Animator animator, string stateName)
    {
        return AnimatorIsPlaying(animator) && animator.GetCurrentAnimatorStateInfo(0).IsName(stateName);
    }

    public static IEnumerator AudioFadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    public static IEnumerator AudioFadeIn(AudioSource audioSource, float FadeTime)
    {
        float startVolume = 0.2f;

        audioSource.volume = 0;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

        audioSource.volume = 1f;
    }

    public static IEnumerator LoadSceneTo(string scene)
    {
        SceneManager.LoadScene(scene);
        yield return new WaitForSeconds(1f);
    }
}