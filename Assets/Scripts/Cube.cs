using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField]private Transform cube1, cube2, cube3;
    public float rotation_speed = 0;

    void Start()
    {
        cube1.Rotate(rotation_speed*Time.deltaTime, 0, 0);
        cube2.Rotate(0, rotation_speed*Time.deltaTime, 0);
        cube3.Rotate(0, 0, rotation_speed*Time.deltaTime);
    }

    void Update()
    {
        
    }
}
