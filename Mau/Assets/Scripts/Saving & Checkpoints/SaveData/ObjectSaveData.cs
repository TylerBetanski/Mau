using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSaveData
{
    public float[] objectPosition;
    public float[] objectRotation;
    public float[] objectScale;

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
