using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    static ScoreKeeper scoreKeeperInit;
    int currentScore;

    void Awake() {
        SingletonScore();
    }

    void SingletonScore()
    {
        if (scoreKeeperInit != null) {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }else {
            scoreKeeperInit = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    public int GetCurrentScore() {
        return currentScore;
    }

    public void SetCurrentScore(int newScore) {
        currentScore += newScore;
        Mathf.Clamp(currentScore, 0, int.MinValue);
        Debug.Log(currentScore);
    }

    public void ResetCurrentScore() {
        currentScore = 0;
    }
}
 