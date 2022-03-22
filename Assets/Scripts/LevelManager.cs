using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    public void LoadMainMenu()
    {
        StartCoroutine(WaitAndLoad(0, loadDelay/2));
    }
    public void LoadGame()
    {
        scoreKeeper.ResetScore();
        StartCoroutine(WaitAndLoad(1, loadDelay/2));
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
