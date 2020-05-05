using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //most variables are public so that they can be tweaked in editor
    private CharacterController _controller;
    public float Speed;
    public int playerHP;
    private int playerMaxHP = 6; 
    private float attackCompleteTime;
    public bool isAttacking;
    public int lanceDamage = 2;
    BoxCollider playerHitbox;
    private float Gravity = - 9.81f;
    public float GRAVITYGAIN = 0.1f;
    private bool _isGrounded = true;
    public Transform _groundChecker;
    public LayerMask Ground;
    private Vector3 _velocity;
    public float GroundDistance;
    Animator anim;
    private bool isDashing;
    public float attackTime = 1.0f;
    private Sequence attackSequence;
    public Transform lance;
    Vector3 lanceRestPositon = new Vector3(-0.0185f, 0.0498f, 0.0009f);
    Vector3 lanceStrikePositon = new Vector3(-0.0182f, 0.0278f, -0.0504f);
    Vector3 lanceStrikeRotation = new Vector3(-89.16f, 0.0f, 0.0f);
    Vector3 playerStartPosition;
    public bool isHoldingRedGem;
    public bool isHoldingBlueGem;

    // Start is called before the first frame update
    void Start()
    {
        playerStartPosition = transform.position;
        playerHP = playerMaxHP;
        _controller = GetComponent<CharacterController>();
        playerHitbox = GetComponentInChildren<BoxCollider>();
        anim = GetComponentInChildren<Animator>();
        isAttacking = false;
        isHoldingRedGem = false;
        isHoldingBlueGem = false;
    }

    // Update is called once per frame
    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);
        if (_isGrounded && _velocity.y < 0)
            _velocity.y = 0f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveHorizontal, 0, moveVertical);
        _controller.Move(move * Time.deltaTime * Speed);

        if (move == Vector3.zero)
        {
            anim.SetBool("isMoving", false);
        }
        else
        {
            anim.SetBool("isMoving", true);

        }
        calculateLocalDirectionAnimation(moveHorizontal, moveVertical);

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

        //attack 
        playerAttack();

        //dash
        playerDash();

        if (transform.position.y < -18)
        {
            fellOffPlatform();
        }
    }

    private void playerAttack()
    {
        if (Input.GetMouseButtonDown(0) && !isAttacking)
        {
            isAttacking = true;
            Debug.Log("attacking");
            anim.SetBool("isAttacking", true);

            attackCompleteTime = Time.time + attackTime;
            moveCollider();

        }
        if (isAttacking && Time.time > attackCompleteTime)
        {
            isAttacking = false;
            anim.SetBool("isAttacking", false);
        }
    }

    private void playerDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("dashing");
            isDashing = true;
            anim.SetBool("isDashing", true);
        }
        else
        {
            isDashing = false;
            anim.SetBool("isDashing", false);
        }
    }

    private void fellOffPlatform()
    {
        //respawn the player at starting point
        transform.position = playerStartPosition;
        //negate fall damage from the HP
        playerHP--;
    }

    private void moveCollider()
    {
        if (attackSequence != null && attackSequence.IsPlaying())
        {
            attackSequence.Kill(true);
        }
        attackSequence = DOTween.Sequence();
        attackSequence.Insert(0f, lance.DOLocalMove(lanceStrikePositon, 0.5f).SetEase(Ease.InOutBack));
        attackSequence.Insert(0f, lance.DOLocalRotate(lanceStrikeRotation, 0.5f).SetEase(Ease.InOutBack));

        attackSequence.Insert(0.7f, lance.DOLocalMove(lanceRestPositon, 0.5f).SetEase(Ease.OutBack));
        attackSequence.Insert(0.7f, lance.DOLocalRotate(new Vector3(0f, 0f, 0f), 0.5f).SetEase(Ease.InOutBack));
    }

    void calculateLocalDirectionAnimation(float x, float z)
    {
        //Debug.Log("start x = " + x + "Start z=" + z);
        float theta = (transform.rotation.y);
        //Debug.Log("theta is: " + theta);
        float _x = x * Mathf.Cos(theta*Mathf.PI) - z * Mathf.Sin(theta * Mathf.PI);
        float _z = x * Mathf.Sin(theta * Mathf.PI) + z * Mathf.Cos(theta * Mathf.PI);
        //TODO more accurate tracking of movement - currently when the player goes +1/+1 in x/z they actually go at 1.4x speed
        //if (Mathf.Abs(_x) > 1 || Mathf.Abs(_z) > 1)
        //{
        //    float maxMagnitude = Mathf.Max(Mathf.Abs(_x), Mathf.Abs(_z));
        //    float minMagnitude = Mathf.Min(Mathf.Abs(_x), Mathf.Abs(_z));
        //    //min divide by max
        //    //max = 1
            

        //    //if (Mathf.Abs(_x) > Mathf.Abs(_z))
        //    //{
        //    //    _z /= _x;
        //    //    _x = 1.0f;
        //    //}
        //}
        anim.SetFloat("Forward", _z);
        anim.SetFloat("Right", _x);


    }

}
