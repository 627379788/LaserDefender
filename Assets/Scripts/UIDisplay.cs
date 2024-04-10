using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    Slider healthValue;
    TextMeshProUGUI scoreValue;
    Health health;
    ScoreKeeper scoreKeeper;

    void Awake() {
        health = FindObjectOfType<Health>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        healthValue = GetComponentInChildren<Slider>();
        scoreValue = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Start() {
        healthValue.maxValue = health.GetHealthValue();
    }
    void Update() {
        healthValue.value = health.GetHealthValue();
        scoreValue.text = scoreKeeper.GetCurrentScore().ToString("0000000000");
    }
}
