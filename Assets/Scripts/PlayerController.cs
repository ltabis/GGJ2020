using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AEntity
{
    // Update is called once per frame
    void Update()
    {
        RotateEntityWithMouse();
        Movements();
    }

    // Handles movements from the player.
    private void Movements()
    {

    }

    // Rotate the object, following the mouse cursor.
    private void RotateEntityWithMouse()
    {
        // Transform position into screen position.
        var pos = Camera.main.WorldToScreenPoint(transform.position);

        // Getting distance between mouse and object.
        var dir = Input.mousePosition - pos;

        // Weird maths 0_0
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        // Applying rotation to the object.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
