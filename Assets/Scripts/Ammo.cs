using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float speedAmmo;
    public float destroyTime;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyAmmo", destroyTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speedAmmo*Time.deltaTime); 
    }
    void DestroyAmmo()
    {
        Destroy(gameObject);
    }
}
