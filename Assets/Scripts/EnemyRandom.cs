using UnityEngine;

public class EnemyRandom : MonoBehaviour
{
    public float speed = 3f;
    public float changeDirectionTime = 2f;

    Vector3 moveDirection;
    float timer;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            float x = Random.Range(-1f, 1f);
            float z = Random.Range(-1f, 1f);
            moveDirection = new Vector3(x, 0, z).normalized;

            if (moveDirection != Vector3.zero)
                transform.forward = moveDirection;

            timer = changeDirectionTime;
        }

        transform.position += moveDirection * speed * Time.deltaTime;
    }
}