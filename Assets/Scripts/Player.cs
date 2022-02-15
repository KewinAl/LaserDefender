using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class Player : MonoBehaviour
{

    Rigidbody2D myrigidbody2D;

    Vector2 rawInput;
    [SerializeField] float moveSpeed = 16f; //Default 16;

    private void Start()
    {
        myrigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Moving();
    }

    private void Moving()
    {
        //process the input from OnMove()
        transform.Translate(new Vector3(rawInput.x, rawInput.y, 0) * moveSpeed * Time.deltaTime);

    }

    private void OnMove(InputValue value)
    {
        //get the InputValue
        rawInput = value.Get<Vector2>();
    }

}
