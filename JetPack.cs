using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour
{
    [HideInInspector] public bool CheckMouseClamp;
    [SerializeField] private float SpeedMove;
    [SerializeField] private float SpeedRotate;
    
    private Transform _thisTransform;

    private Vector2 _mousePosition;
    private Vector2 _direction;
    private Vector2 _currentDirection;
    private Vector2 _myTransformPosition;

    void Start()
    {
        _thisTransform = this.transform;
        CheckMouseClamp = false;
    }


    void Update()
    {
        MouseClamp();

        if(CheckMouseClamp)
        {
            FlyJetPack();
        }
    }

    private void MouseClamp()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CheckMouseClamp = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            CheckMouseClamp = false;
        }  
    }

    private void FlyJetPack()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _myTransformPosition = _thisTransform.position;

        _direction = _mousePosition - _myTransformPosition;
        _direction.Normalize();

        _currentDirection = Vector2.Lerp(_currentDirection, _direction, SpeedRotate * Time.deltaTime);
        _thisTransform.up = _currentDirection;

        if (Vector2.Distance(_myTransformPosition, _mousePosition) > 1f)
        {
            transform.Translate(Vector3.up * SpeedMove * Time.deltaTime);
        }
    }
}


