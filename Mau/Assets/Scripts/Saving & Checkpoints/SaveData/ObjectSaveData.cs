using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaveData
{
    private float[] objectPosition;
    private float[] objectRotation;
    private float[] objectScale;

    public ObjectSaveData(Transform transform)
    {
        FillArray(ref objectPosition, transform.position);
        FillArray(ref objectRotation, transform.localEulerAngles);
        FillArray(ref objectScale, transform.localScale);
    }

    private void FillArray(ref float[] array, Vector3 data)
    {
        array = new float[3];
        array[0] = data.x;
        array[1] = data.y;
        array[2] = data.z;
    }

    public Vector3 GetPosition() {
        return new Vector3(objectPosition[0], objectPosition[1], objectPosition[2]);
    }
    public Vector3 GetRotation()
    {
        return new Vector3(objectRotation[0], objectRotation[1], objectRotation[2]);
    }
    public Vector3 GetScale()
    {
        return new Vector3(objectScale[0], objectScale[1], objectScale[2]);
    }
}

public class ObjectSaveData_Physics : ObjectSaveData
{
    private float[] velocity;
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

public class ObjectSaveData_RotatableObject : ObjectSaveData
{
    public int currentState = 0;

    public ObjectSaveData_RotatableObject(Transform transform, RotatableObject rotateObject) : base(transform)
    {
        currentState = rotateObject.GetCurrentState();
    }
}

public class ObjectSaveData_Enemy : ObjectSaveData
{
    public int moveSpeed;

    public ObjectSaveData_Enemy(Transform transform, EnemyMovement enemyMovement) : base(transform)
    {
        moveSpeed = enemyMovement.MoveSpeed;
    }
}

public class ObjectSaveData_Sarcophagus : ObjectSaveData
{
    private bool open;
    private bool shouldClose;

    public ObjectSaveData_Sarcophagus(Transform transform, Sarcophagus sarc) : base(transform)
    {
        open = sarc.Open;
        shouldClose = sarc.ShouldClose;
    }
}

public class ObjectSavaData_CrystalEmitter : ObjectSaveData {
    public bool active;
    public float angle;
    
    public ObjectSavaData_CrystalEmitter(Transform transform, CrystalEmitter emitter) : base(transform) {
        active = emitter.isActive();
        angle = emitter.getAngle();
    }
}

public class ObjectSaveData_Pot : ObjectSaveData {

    public bool isPotDestroyed;

    public ObjectSaveData_Pot(Transform transform, bool ipd) : base(transform) {
        isPotDestroyed = ipd;
    }
}