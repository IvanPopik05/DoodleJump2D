using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    private void LateUpdate()
    {
        if(!_target)
            return;
        
        if (_target.position.y > transform.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x,_target.position.y,transform.position.z);
            transform.position = newPos;
        }
    }
}