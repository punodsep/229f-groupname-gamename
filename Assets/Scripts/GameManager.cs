using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public int hp = 3;

    public Transform hole;
    public GameObject enemyPrefab;

    public void ReachHole()
    {
        score++;

        hole.position = new Vector3(Random.Range(-16, 16), 0, Random.Range(-9, 9));

        Instantiate(enemyPrefab, new Vector3(Random.Range(-16, 16), 1, Random.Range(-9, 9)), Quaternion.identity);
    }

    public void TakeDamage()
    {
        hp--;

        if (hp <= 0)
        {
            Debug.Log("Game Over");
            Time.timeScale = 0;
        }
    }
}