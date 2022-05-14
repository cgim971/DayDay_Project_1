using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PartyController : MonoBehaviour
{

    private Rigidbody2D _theRigid;
    public JoyStick _joystick;
    [SerializeField] private float _speed = 5f;

    private void Start()
    {
        _theRigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _theRigid.velocity = _joystick.PosValue * _speed;
        
        transform.eulerAngles = _joystick.RotationValue;

        for(int i = 0 ; i < 3; i++)
        {
            transform.GetChild(i).transform.localEulerAngles = -_joystick.RotationValue;
        }
    }
}
