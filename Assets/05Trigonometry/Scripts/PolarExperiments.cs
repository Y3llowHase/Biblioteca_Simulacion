using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolarExperiments : MonoBehaviour
{
    [SerializeField] float radius;
    [SerializeField] float angleDeg;

    [Header("Speed and Acceleration")]
    [SerializeField] float angularSpeed;
    [SerializeField] float angularAccel;
    [SerializeField] float radialSpeed;
    [SerializeField] float radialAccel;

    [Header("World")]
    [SerializeField] Transform bolita;

    private void Start()
    {
        //Assert.IsNotNull(bolita, "Bolita reference is required");
    }

    
    private void Update()
    {
        //Increment the angle and rad
        angleDeg += angularSpeed * Time.deltaTime;
        radius += radialSpeed * Time.deltaTime;

        //Update the bolita position       
        bolita.position = PolartoCartesian(radius, angleDeg);
        Debug.DrawLine(Vector3.zero, bolita.position, Color.green);
    }

    private Vector2 PolartoCartesian (float radius, float angle)
    {
        float x = radius * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new Vector3(x, y, 0);
    }
}
