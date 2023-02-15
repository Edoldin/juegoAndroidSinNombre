using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Camera screenCamera;
    private Vector2 mousePos;
    public Entity Owner;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void move()
    {
        mousePos = screenCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 aimDir = mousePos -  Owner.getPos();
        Debug.Log(aimDir);
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        Debug.Log(aimAngle);
        transform.rotation = Quaternion.Euler (0, 0, aimAngle);
        //transform.RotateAround(Owner.getPos(), new Vector3(0, 1, 0), aimAngle);

    }
}
