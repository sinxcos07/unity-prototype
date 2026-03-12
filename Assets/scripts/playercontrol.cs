using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class playercontrol : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float baseSpeed = 15f;
    [SerializeField] float boostAmount = 20f;
    InputAction moveAction;
    Rigidbody2D myrigidbody2d;
    Vector2 moveVector;
    SurfaceEffector2D mysurfaceEffector2D;
    bool canMove = true;
    float previousrotation;
    float totalrotation;
    
    scoremanager scoree;
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        myrigidbody2d = GetComponent<Rigidbody2D>();
        mysurfaceEffector2D = FindFirstObjectByType<SurfaceEffector2D>();
        scoree = FindFirstObjectByType<scoremanager>();
        


    }
    void Update()
    {
        if (canMove)
        {
            RotatePlayer();
            BoostPlayer();
            calculateFlips();

        }
         


    }

    void calculateFlips()
    {
        float currentrotation = transform.rotation.eulerAngles.z;
        totalrotation += Mathf.DeltaAngle(previousrotation, currentrotation);
        if (totalrotation > 340 || totalrotation < -340)
        {
            
            totalrotation = 0;
            scoree.addscore(100);
        }

        previousrotation = currentrotation;
    }

    void RotatePlayer()
    {
        
        moveVector = moveAction.ReadValue<Vector2>();
        if (moveVector.x < 0)
            myrigidbody2d.AddTorque(torqueAmount);
        else if (moveVector.x > 0)
            myrigidbody2d.AddTorque(-torqueAmount);

    }
    void BoostPlayer()
    {
        if (moveVector.y > 0)
        {
            mysurfaceEffector2D.speed = boostAmount;
        }
        else
        {
             mysurfaceEffector2D.speed = baseSpeed;
        }
   


    }
    public void DisableControl()
    {
        canMove = false;
    }

}