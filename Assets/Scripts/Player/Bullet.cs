using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed    = 10f;
    public int   damage   = 10;
    public float lifespan = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x + transform.forward.x * Time.deltaTime * speed, transform.position.y , transform.position.z + transform.forward.z * Time.deltaTime * speed);
        Lifetime();
    }

    private void Lifetime()
    {
        lifespan -= Time.deltaTime;
        if (lifespan <= 0 && gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            lifespan = 2f;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        gameObject.SetActive(false);
        lifespan = 2f;
    }
}
