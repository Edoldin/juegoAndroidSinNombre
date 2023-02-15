using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    protected Rigidbody2D rg;
    public float hp;
    public float speed;
    // Start is called before the first frame update
    public virtual void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Vector2 getPos()
    {
        return new Vector2(rg.position.x, rg.position.y);
    }
}