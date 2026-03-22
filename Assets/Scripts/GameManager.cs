using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int highScore = 0;
    public int hp = 3;
    public float timeLeft = 60f;

    [Header("UI Elements")]
    public Slider hpBar;
    public Slider timeBar;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    public Transform hole;
    public GameObject enemyPrefab;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        hpBar.maxValue = hp;
        hpBar.value = hp;

        timeBar.maxValue = timeLeft;
        timeBar.value = timeLeft;

        scoreText.text = "Score: " + score;
        highScoreText.text = "HighScore: " + highScore;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) timeLeft = 0;

        timeBar.value = timeLeft;

        if (timeLeft <= 0)
        {
            GameOver();
        }
    }

    public void ReachHole()
    {
        score++;
        scoreText.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "HighScore: " + highScore;
        }

        hole.position = new Vector3(Random.Range(-16, 16), 0, Random.Range(-9, 9));

        Instantiate(enemyPrefab, new Vector3(Random.Range(-16, 16), 1, Random.Range(-9, 9)), Quaternion.identity);
    }

    public void Damage()
    {
        hp--;
        if (hp < 0) hp = 0;
        hpBar.value = hp;

        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = "HighScore: 0";
        Debug.Log("HighScore reset!");
    }
}