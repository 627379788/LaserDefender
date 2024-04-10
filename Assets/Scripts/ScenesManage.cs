using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManage : MonoBehaviour
{
    [SerializeField] float loadDelay = 2f;
    ScoreKeeper scoreKeeper;

    void Awake() {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    public void LoadGame(){
        if(scoreKeeper == null)   
        {
            scoreKeeper = FindObjectOfType<ScoreKeeper>();
        }
        scoreKeeper.ResetCurrentScore();
        SceneManager.LoadScene("Game");
    }
    public void LoadMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void LoadGameOver(){
        StartCoroutine(WaitAndLoad("OverGame", loadDelay));
    }
    public void QuitGame(){
        Debug.Log("is quiting game.....");
        Application.Quit();
    }

    IEnumerator WaitAndLoad(string gameName, float delay) {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(gameName);
    }
}
