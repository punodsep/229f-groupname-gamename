using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveAcceleration = 10f;

    [Header("Dash")]
    public float dashForce = 20f;
    public float dashDuration = 0.2f;

    [Header("Spin (Stun)")]
    public float spinSpeed = 15f;
    public float spinDuration = 1f;

    Rigidbody rb;

    bool isDashing = false;
    bool isSpinning = false;

    public GameManager gm;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && !isSpinning)
        {
            StartCoroutine(DashAndSpin());
        }
    }

    void FixedUpdate()
    {
        if (!isDashing && !isSpinning)
        {
            Move();
        }

        if (isSpinning)
        {
            rb.angularVelocity = new Vector3(0, spinSpeed, 0);
        }
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(h, 0, v);

        if (direction.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }
        float mass = rb.mass;
        Vector3 force = rb.mass * moveAcceleration * direction;

        rb.AddForce(force);
    }

    IEnumerator DashAndSpin()
    {
        isDashing = true;

        Vector3 direction = transform.forward;
        rb.AddForce(direction * dashForce, ForceMode.Impulse);

        yield return new WaitForSeconds(dashDuration);

        isDashing = false;

        isSpinning = true;

        yield return new WaitForSeconds(spinDuration);

        isSpinning = false;
        rb.angularVelocity = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hole"))
        {
            gm.ReachHole();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            gm.Damage();
        }
    }

}