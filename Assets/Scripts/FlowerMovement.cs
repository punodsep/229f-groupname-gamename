using UnityEngine;

public class FlowerMovement : MonoBehaviour
{
    public float bloomSpeed = 2f;

    public float swayAmount = 5f;
    public float swaySpeed = 1f;

    private Vector3 targetScale;
    private Quaternion startRotation;

    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero;

        startRotation = transform.rotation;
    }

    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * bloomSpeed);

        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmount;
        transform.rotation = startRotation * Quaternion.Euler(0, 0, sway);
    }
}
