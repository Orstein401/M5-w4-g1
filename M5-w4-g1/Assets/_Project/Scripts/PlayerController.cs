using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] private float speed;

    [Header("Input")]
    private float h;
    private float v;
    private bool run;

    [Header("newVelocity")]
    private Vector3 dir;
    private Vector3 newVelocity;

    [Header("Ground")]

    [Header("Ground parametres")]
    [SerializeField] private Transform checkerGround;
    [SerializeField] private float radius;
    [SerializeField] private float maxDistance;

    [Header("TypeGround")]
    [SerializeField] private LayerMask grounds;
    private TypeGround walkedGround;
    //Get
    public Vector3 Velocity
    {
        get => newVelocity;
    }
    public float Horizontal
    {
        get => h;
    }
    public float Vertical
    {
        get => v;
    }

    public bool Run
    {
        get => run;
    }

    public TypeGround WalkedGround
    {
        get => walkedGround;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        GetInput();
        CalculateVelocity();
        IsRunning();
        CheckGroundType();
    }
    private void FixedUpdate()
    {
        if (newVelocity != Vector3.zero)
        {
            rb.velocity = newVelocity;
        }

    }

    public void GetInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        run = Input.GetKey(KeyCode.LeftShift);
    }

    public void CalculateVelocity()
    {
        dir = new Vector3(h, 0, v);
        dir.Normalize();
        newVelocity = dir * speed;
        newVelocity.y = rb.velocity.y;
    }

    public void IsRunning()
    {
        if (run&&dir!=Vector3.zero)
        {
            newVelocity *= 2;
            newVelocity.y = rb.velocity.y;
        }
    }

    public void CheckGroundType()
    {
        if (Physics.SphereCast(checkerGround.position, radius, -transform.up, out var hit, maxDistance, grounds))
        { 
            if (hit.collider.gameObject.CompareTag("Dirt"))
            {
                walkedGround = TypeGround.Dirt;
                Debug.Log("sta toccando terra");
            }
            if (hit.collider.gameObject.CompareTag("Stone"))
            {
                walkedGround = TypeGround.Stone;
                Debug.Log("sta toccando pietra"+walkedGround);
            }
            if (hit.collider.gameObject.CompareTag("Wood"))
            {
                walkedGround = TypeGround.Wood;
                Debug.Log("sta toccando legno" + walkedGround);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(checkerGround.position, radius);
    }
}
