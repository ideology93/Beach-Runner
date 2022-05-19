using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Vector3 currentPosition;
    private Vector3 rotate;
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private float floatSpeed;
    public Camera cam;
    public float numb1;
    public float numb2;
    public float numb3;
    public bool isFloating;
    float y;

    void Start()
    {
        currentPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
    void FixedUpdate()
    {
        if (!isFloating)
        {
            y = Mathf.PingPong(Time.time * floatSpeed, numb1) * numb2 - numb3;
        }
        else
        {
            y =  currentPosition.y - Mathf.PingPong(Time.time * floatSpeed, numb1) *  numb2 - numb3;
        }
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
        transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime));
    }

}
