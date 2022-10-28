using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// code van https://www.youtube.com/watch?v=o9l699x_qZM&ab_channel=Zarriix
public class Movement : MonoBehaviour
{
    [SerializeField] float thrusterForce = 10f;
    [SerializeField] float tiltingForce = 10f;

    Rigidbody rocket;



    private void Awake()
    {
        rocket = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float tilt = Input.GetAxis("Horizontal");
        if (!Mathf.Approximately(tilt, 0f))
        {
            rocket.freezeRotation = true;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + (new Vector3(0f, 0f, (tilt * tiltingForce * Time.deltaTime))));
        }

        rocket.freezeRotation = false;
    }
    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rocket.AddRelativeForce(Vector3.up * thrusterForce * Time.deltaTime);
        }
    }
}
