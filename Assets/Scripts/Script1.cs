using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    [SerializeField] MyVector2D MyFirstVector = new MyVector2D(2, 3);
    [SerializeField] MyVector2D MySecondVector = new MyVector2D(3, 4);
    [Range(0, 1)] [SerializeField] float scalar = 0;

    void Start()
    {
        Vector2 au = new Vector2(2, 3);
        Vector2 bu = new Vector2(4, 5);
    }

    // Update is called once per frame
    void Update()
    {
        MyFirstVector.Draw(Color.red);
        MySecondVector.Draw(Color.green);

        //Multiplicación por escalar
        //MyVector2D result = (MyFirstVector - MySecondVector) * scalar;
        //result.Draw(MySecondVector, Color.yellow);

        //Suma
        //MyVector2D result = MyFirstVector + MySecondVector;
        //result.Draw(Color.yellow);

        //Resta
        //MyVector2D result = MyFirstVector - MySecondVector;
        //result.Draw(Color.yellow);
        //result.Draw(MySecondVector, Color.yellow);

        //Multiplicación
        MyVector2D multi = (MySecondVector - MyFirstVector)*scalar;
        //multi.Draw(Color.yellow);
        multi.Draw(MyFirstVector, Color.yellow);

        //Vector Final
        MyVector2D final = multi + MyFirstVector;
        final.Draw(Color.blue);
        //final.Draw(MyFirstVector, Color.blue);
        //final.Draw(MySecondVector, Color.blue);
        
        
    }
}
