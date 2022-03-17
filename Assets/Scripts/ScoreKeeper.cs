using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int score = 0;
    static ScoreKeeper instance;

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {

        if (instance != null)
        {
            gameObject.SetActive(false);//UnityThings
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        };

    }

    public int GetScore()
    {
        return score;
    }

    public void ResetScore()
    {
        score = 0;
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
    }
}
