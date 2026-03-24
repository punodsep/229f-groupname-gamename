using UnityEngine;
using TMPro;

public class DashPhysics : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI forceDisplay; 

    [Header("Physics Settings")]
    public float mass = 0.5f;        
    public float acceleration = 20f; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PerformDash();
        }
    }

    void PerformDash()
    {
        float forceValue = mass * acceleration;
         
        if (forceDisplay != null)
        {
            forceDisplay.text = "Dash Force: " + forceValue.ToString("F2") + " N";
        }

        rb.AddForce(transform.forward * forceValue, ForceMode.Impulse);
    }
}
