using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    void Update()
    {
        transform.Translate(transform.up * _speed * Time.deltaTime);
    }
}