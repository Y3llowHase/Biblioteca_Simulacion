using System;
using UnityEngine;

[Serializable]

struct MyVector2D
{
    public float x;
    public float y;

    public MyVector2D (float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public void Draw (Color color)
    {
        Debug.DrawLine(
            Vector3.zero, new Vector3(x, y), color
            );
    }

    public void Draw(MyVector2D newOrigin, Color color)
    {
        Debug.DrawLine(
            new Vector3(newOrigin.x, newOrigin.y, 0),
            new Vector3(newOrigin.x + x, newOrigin.y + y, 0),
            color
            );
    }

    public static MyVector2D operator +(MyVector2D a, MyVector2D b)
    {
        
        return new MyVector2D(a.x + b.x, a.y + b.y);
    }

    public static MyVector2D operator -(MyVector2D a, MyVector2D b)
    {

        return new MyVector2D(a.x - b.x, a.y - b.y);
    }

    public static MyVector2D operator *(MyVector2D a, float b)
    {

        return new MyVector2D(a.x * b, a.y * b);
    }

}

