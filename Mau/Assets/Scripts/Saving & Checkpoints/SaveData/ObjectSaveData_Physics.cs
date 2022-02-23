using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaveData_Physics : ObjectSaveData
{
    public float[] velocity;
    public float angularVelocity;

    public ObjectSaveData_Physics(Transform transform, Rigidbody2D rb2D) : base(transform)
    {
        velocity = new float[2];
        velocity[0] = rb2D.velocity.x;
        velocity[1] = rb2D.velocity.y;
        angularVelocity = rb2D.angularVelocity;
    }

    public Vector2 GetVelocity()
    {
        return new Vector2(velocity[0], velocity[1]);
    }
}
