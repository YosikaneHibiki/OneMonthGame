using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCar : MonoBehaviour
{
    [SerializeField]
    private Rigidbody car_Rigidbody;
    [SerializeField]
    private float moveSpeed;


    private void Update()
    {

        float x = Input.GetAxisRaw("Horizontal");

        float z = Input.GetAxisRaw("Vertical");
        car_Rigidbody.AddForce(new Vector3 (x, 0, z).normalized*moveSpeed);
    }

}
