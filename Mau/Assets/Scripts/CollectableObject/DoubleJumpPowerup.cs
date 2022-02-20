using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpPowerup : CollectableObject
{
    // Collect is called when the player collides with this scripts parent object
    public override void Collect(PlayerController PC) 
    {
        PC.enableDoubleJump();
    }
}
