using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad(0, loadDelay));
    }
    public void LoadGame()
    {
        StartCoroutine(WaitAndLoad(1, loadDelay));
    }
    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad(2, loadDelay));
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    IEnumerator WaitAndLoad(int sceneIndex,float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneIndex);

    }


}
