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

    public float Horizontal
    {
        get => h;
    }
    public float Vertical
    {
        get => v;
    }

    public void GetInput()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
    }

    public void CalculateVelocity()
    {

    }

}
