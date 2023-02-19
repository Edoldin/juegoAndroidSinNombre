using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool       instance;
    public        GameObject       prefab;
    public        List<GameObject> pooledBullets;
    public        int              poolLength     = 20;

    private void Awake()
    {
        if(instance == null)
            instance = this;
        pooledBullets = new List<GameObject>();
        for (int i = 0; i < poolLength; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            pooledBullets.Add(obj);
        }
    }

    public GameObject GetPooledBullet()
    {
        for (int i = 0; i < pooledBullets.Count; i++)
        {
            if (!pooledBullets[i].activeInHierarchy)
            {
                return pooledBullets[i];
            }
        }
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
