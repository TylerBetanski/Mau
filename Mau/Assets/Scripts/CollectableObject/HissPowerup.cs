using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HissPowerup : CollectableObject
{
    // Collect is called when the player collides with this scripts parent object
    public override void Collect(PlayerController PC)
    {
        PC.enableHiss();
    }
}
