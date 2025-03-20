using UnityEngine;

public class car : MonoBehaviour
{
    public Rigidbody rigid;
    public wheels[] wheels;
    public float drivespeed, steerspeed;

    void FixedUpdate()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        Rigidbody rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1, 0);

        float motor = verticalInput * drivespeed;
        for (int i = 0; i < wheels.Length; i++)
        {
            var wheelCollider = wheels[i].wheelCollider;
            wheelCollider.motorTorque = motor;

            if (wheels[i].wheelTurn == true)
            {
                wheelCollider.steerAngle = steerspeed * -horizontalInput;
            }
        }
    }
}
