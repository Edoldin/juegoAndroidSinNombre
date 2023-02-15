using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : Entity
{
    public string[] key_bindings;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void trackMouse()
    {
    }

    void move(){
        float mx = Input.GetAxis("Horizontal") * speed;
        float my = Input.GetAxis("Vertical") * speed;
        rg.velocity = new Vector2(mx, my);
    }

    
}
