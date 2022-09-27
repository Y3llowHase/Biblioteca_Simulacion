using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolitawithForce : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [SerializeField] private MyVector2D force;
    [SerializeField] private float mass = 1f;
    

    [Header("Forces")]
    [SerializeField] private MyVector2D wind;
    [SerializeField] private MyVector2D gravity;
    private MyVector2D netForce;

    [Header("World")]
    [SerializeField] Camera camera;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;
    [Range(0f, 1f)] [SerializeField] private float frictionCoefficient = 0.9f;





    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {

        Vector2 p = Vector2.one;
        Vector2 pUnit = p.normalized;
        //netForce = new MyVector2D(0, 0);
        acceleration = new MyVector2D(0, 0);

        //weight
        MyVector2D weight = gravity * mass;
        ApplyForce(weight);
        
        //friction
        MyVector2D friction = -frictionCoefficient * weight.magnitude * velocity.normalized;
        ApplyForce(friction);
        

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
        velocity = velocity + acceleration * Time.deltaTime;
        position = position + velocity * Time.deltaTime;

        if (Mathf.Abs(position.x)> camera.orthographicSize)
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

        transform.position = new Vector3 (position.x, position.y);
    }

    private void ApplyForce(MyVector2D force)
    {
        acceleration += force/ mass; 
        
    }
}
