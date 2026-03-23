using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public int score = 0;
    public int highScore = 0;
    public int hp = 3;
    public float timeLeft = 60f;
    public float wait = 1f;

    public Transform hole;
    public GameObject enemyPrefab;
    public ParticleSystem endParticle;

    [Header("UI Elements")]
    public Slider hpBar;
    public Slider timeBar;
    public TMP_Text scoreText;
    public TMP_Text highScoreText;

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);

        hpBar.maxValue = hp;
        hpBar.value = hp;

        timeBar.maxValue = timeLeft;
        timeBar.value = timeLeft;

        scoreText.text = "" + score;
        highScoreText.text = "HighScore: " + highScore;
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0) timeLeft = 0;

        timeBar.value = timeLeft;

        if (timeLeft <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    public void ReachHole()
    {
        score++;
        scoreText.text = "" + score;

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            highScoreText.text = "HighScore: " + highScore;
        }

        hole.position = new Vector3(Random.Range(-17, 17), 0, Random.Range(-9, 6));

        Instantiate(enemyPrefab, new Vector3(Random.Range(-17, 17), 1, Random.Range(-9, 6)), Quaternion.identity);
    }

    public void Damage()
    {
        hp--;
        if (hp < 0) hp = 0;
        hpBar.value = hp;

        if (hp <= 0)
        {
            StartCoroutine(GameOver());
        }
    }

    IEnumerator GameOver()
    {
        Debug.Log("Game Over");
        
        yield return new WaitForSeconds(wait);
        endParticle.Play();
        yield return new WaitForSeconds(wait);

        pauseMenu.Pause();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        highScore = 0;
        highScoreText.text = "HighScore: 0";
        Debug.Log("HighScore reset!");
    }
}