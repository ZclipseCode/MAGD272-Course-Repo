using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootCollectionDemo : MonoBehaviour
{
    public KeyCode shootButton;
    public Transform shootPoint;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(shootButton))
        {
            useInstance();
        }
    }

    void useInstance()
    {
        GameObject _object = BulletPooler.SharedInstance.GetPoolObject();
        // add position code
        _object.transform.position = shootPoint.position;
        // add rotation code
        _object.transform.rotation = transform.rotation;
        _object.SetActive(true);
    }
}
