using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolitawithForceCopy : MonoBehaviour
{
    public enum BolitaRunMode
    {
        Friction,
        FluidFriction,
        Gravity
    }

    public float Mass => mass;

    private MyVector2D position;
    [SerializeField] private BolitaRunMode runMode;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private float mass = 1f;

    
        

    [Header("Forces")]
    [SerializeField] private MyVector2D wind;
    [SerializeField] private MyVector2D gravity;
    

    [Header("World")]
    [SerializeField] Camera camera;
    [SerializeField] private MyBolitawithForceCopy otherBolita;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float frictionCoefficient = 0.9f;
    [SerializeField] private bool useFluidFriction = false; 




    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {
        Vector2 p = Vector2.one;
        Vector2 pUnit = p.normalized;
        //reset acceleration
        acceleration *= 0;

        //Some frictions
        if (runMode == BolitaRunMode.FluidFriction)
        {
            //weight
            MyVector2D weight = gravity * mass;
            ApplyForce(weight);

            //Fluid friction
            ApplyFluidFriction(); 
        }
        else if (runMode == BolitaRunMode.Friction)
        {
            //weight
            MyVector2D weight = gravity * mass;
            ApplyForce(weight);

            //Firction
            ApplyFriction();
        }
        else if (runMode == BolitaRunMode.Gravity)
        {
            MyVector2D diff = otherBolita.position - position;
            float distance = diff.magnitude;
            float scalarPart = (mass * otherBolita.mass) / (distance * distance);
            MyVector2D gravityForce = diff.normalized * scalarPart;
            ApplyForce(gravityForce);
        }
        
        

        //wind
        ApplyForce(wind);

        //Integrate acceleration
        move();

       
    }

    
    void Update()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);
        
        

        
    }

    public void move()
    {
        //Euler Integrator
        velocity = velocity + acceleration * Time.deltaTime;
        position = position + velocity * Time.deltaTime;

        //World it's a box only if not simulating gravity attraction 
        if (runMode != BolitaRunMode.Gravity)
        {
            CheckWorldBoxBounds();
        }

        //Tell unity what's the new object position
        transform.position = new Vector3(position.x, position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration += force/ mass; 
        
    }

    void ApplyFriction()
    {
        //friction
        float N = -mass * gravity.y;
        MyVector2D friction = -frictionCoefficient * N * velocity.normalized;
        ApplyForce(friction);
        friction.Draw(position, Color.blue);
    }

    private void ApplyFluidFriction()
    {
        if (transform.localPosition.y >= 0)
        {
            //Input variables
            float frontalArea = transform.localScale.x;
            float rho = 1; //densidad
            float fluidDragCoefficient = 1;
            float velocityMagnitude = velocity.magnitude;

            //Calculate the force
            float scalarPart = -0.5f * rho * velocityMagnitude * velocityMagnitude * frontalArea * fluidDragCoefficient;
            MyVector2D friction = scalarPart * velocity.normalized;
            ApplyForce(friction);
        }

    }

    private void CheckWorldBoxBounds ()
    {
        if (Mathf.Abs(position.x) > camera.orthographicSize)
        {
            velocity.x = velocity.x * -1;
            position.x = Mathf.Sign(position.x) * camera.orthographicSize;
            velocity *= dampingFactor;

        }

        else if (position.x < -camera.orthographicSize)
        {
            velocity.x *= -1;
            position.x = -camera.orthographicSize;
            velocity *= dampingFactor;
        }

        if (Mathf.Abs(position.y) > camera.orthographicSize)
        {
            velocity.y = velocity.y * -1;
            position.y = Mathf.Sign(position.y) * camera.orthographicSize;
            velocity *= dampingFactor;
        }

        else if (position.y < -camera.orthographicSize)
        {
            velocity.y *= -1;
            position.y = -camera.orthographicSize;
            velocity *= dampingFactor;
        }
    }


}
