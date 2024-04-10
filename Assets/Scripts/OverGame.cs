using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class OverGame : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    ScoreKeeper scoreKeeper;
    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    void Start()
    {
        textMeshPro.text = "You Score:\n"  + scoreKeeper.GetCurrentScore();
    }

}
