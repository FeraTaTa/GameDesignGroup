using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController _controller;
    public float Speed;
    int playerHP;
    public bool attacking;
    BoxCollider playerHitbox;
    private float Gravity = - 9.81f;
    public float GRAVITYGAIN = 0.1f;
    private bool _isGrounded = true;
    public Transform _groundChecker;
    public LayerMask Ground;
    private Vector3 _velocity;
    public float GroundDistance;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = 0;
        _controller = GetComponent<CharacterController>();
        playerHitbox = GetComponentInChildren<BoxCollider>();
        attacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * Speed);

        Vector3 lookTarget;
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            lookTarget = hit.point;
            lookTarget.y = transform.position.y;
            transform.LookAt(lookTarget);
        }
        _velocity.y += Gravity * Time.deltaTime * GRAVITYGAIN;
        _controller.Move(_velocity * Time.deltaTime * Speed);
    }

}
