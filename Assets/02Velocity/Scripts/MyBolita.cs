using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyBolita : MonoBehaviour
{
    private MyVector2D position;
    [SerializeField] private MyVector2D acceleration;
    [SerializeField] private MyVector2D velocity;
    [Range(0f, 1f)] [SerializeField] private float dampingFactor = 0.9f;

    [Header("World")]
    [SerializeField] Camera camera;

    private int currentAccelerationCounter = 0;
    private readonly MyVector2D[] directions = new MyVector2D[4]
    {
         new MyVector2D (0, -9.8f),
         new MyVector2D (9.8f, 0f),
         new MyVector2D (0, 9.8f),
         new MyVector2D (-9.8f, 0f),
    }; 





    void Start()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
    }

    private void FixedUpdate()
    {

    }

    
    void Update()
    {
        position = new MyVector2D(transform.position.x, transform.position.y);
        position.Draw(Color.blue);
        velocity.Draw(position, Color.red);
        acceleration.Draw(position, Color.green);
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            acceleration = directions[(++currentAccelerationCounter) % directions.Length];
            velocity *= 0;
        }

        move();
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

        transform.position = new Vector3(position.x, position.y);
    }
}
