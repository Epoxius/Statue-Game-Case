using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public DynamicJoystick dynamicJoystick;
    public GameObject joystick;
    public Rigidbody rb;
    public Animator playerAnim;
    public Transform moneyTransform;

    void Update()
    {
        if (GameManager.Instance.gameState != GameManager.GameState.Start) return;
        Move();
        AnimatonController();
    }

    public void Move()
    {
        Vector3 direction = Vector3.forward * dynamicJoystick.Vertical + Vector3.right * dynamicJoystick.Horizontal;
        rb.velocity = direction * speed * Time.fixedDeltaTime;
        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    public void AnimatonController()
    {
        if (rb.velocity == Vector3.zero)
        {
            playerAnim.SetTrigger("Idle");
        }
        else
        {
            playerAnim.SetTrigger("Run");
        }
    }
}