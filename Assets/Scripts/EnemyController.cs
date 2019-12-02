using UnityEngine;
using System.Collections;

[RequireComponent(typeof(GravityBody))]
public class EnemyController : MonoBehaviour
{

    // public vars

    public float walkSpeed = 6;
    public LayerMask groundedMask;
    public Transform target;

    // System vars

    Vector3 moveAmount;
    Vector3 smoothMoveVelocity;
    float verticalLookRotation;
    Rigidbody rigidbody;


    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {


        // Calculate movement:

        Vector3 targetMoveAmount = target.position * walkSpeed;
        moveAmount = Vector3.SmoothDamp(moveAmount, targetMoveAmount, ref smoothMoveVelocity, .15f);

     

    }

    void FixedUpdate()
    {
        // Apply movement to rigidbody
        Vector3 localMove = transform.TransformDirection(moveAmount) * Time.fixedDeltaTime;
        rigidbody.MovePosition(rigidbody.position + localMove);
    }
}