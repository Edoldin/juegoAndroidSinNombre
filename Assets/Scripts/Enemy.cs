using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected Rigidbody2D rg;
    public float hp;
    public float speed;

    protected virtual void Awake()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public Vector2 getPos()
    {
        return new Vector2(rg.position.x, rg.position.y);
    }
}
