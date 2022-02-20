using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartContainer : CollectableObject
{
    // Collect is called when the player collides with this scripts parent object
    public override void Collect(PlayerController PC) 
    {
        PC.increaseMaxHealth();
        // Add animation
    }
}
