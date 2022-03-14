using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    
    [Header("Score")]
    ScoreKeeper scoreKeeper;
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Health")]
    [SerializeField] Health playerHealth;
    [SerializeField] Slider healthSlider;


    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    private void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }
    private void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        scoreText.text = scoreKeeper.GetScore().ToString(); ;
    }



}
