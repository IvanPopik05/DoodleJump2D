using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Player_Container;
using Pool_Container;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 10f;
    
    private IPool<Platform> _pool;
    private Camera _camera;
    private Transform _lowerCameraPosition;

    // public virtual void Construct(IPool<Platform> pool, Transform lowerCameraPosition)
    // {
    //     _lowerCameraPosition = lowerCameraPosition;
    //     _pool = pool;
    // }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Rigidbody2D rb) && collision.relativeVelocity.y <= 0)
        {
            Vector2 velocity = rb.velocity;
            velocity.y = _jumpForce;
            rb.velocity = velocity;
        }
    }
    // public virtual void Update()
    // {
    //     if (transform.position.y < _lowerCameraPosition.position.y)
    //     {
    //         _pool.ReturnToPull(this);
    //     }
    // }
}

public interface IPlatform
{
    //void Construct(IPool<Platform> pool, Transform lowerCameraPosition);
    void CheckCollision(Rigidbody2D rigidbody2D);
}
