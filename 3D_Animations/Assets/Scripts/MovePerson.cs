using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePerson : MonoBehaviour
{
    CapsuleCollider capsuleCollider;
    public Transform CameraTransform;
    public CharacterStatus characterStatus;
    public Animator animator;
    private Rigidbody rb;
    
    public float vertical;
    public float horizontal;
    public float moveAmount;
    public float rotationSpeed;
    

    public Vector3 rotationDirection;
    public Vector3 moveDirection;

    public void MoveUpdate()
    {
        
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));
        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        moveDirection = moveDir;
        rotationDirection = CameraTransform.forward;
        RotationNormal();
        
    }

   
   
    public void RotationNormal()
    {
        if(!characterStatus.isAiming)
        {
            rotationDirection = moveDirection;
        }
        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;
        if(targetDir == Vector3.zero)
            targetDir = transform.forward;
        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;
    }

    
}
