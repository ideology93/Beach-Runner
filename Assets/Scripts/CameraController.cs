using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private float z;
    void Awake()
    {


    }
    void Update()
    {
        z = player.transform.position.z - 1;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, z);
    }
}
