using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    bool facingRight = true;
    public float offset;
    public GameObject ammo;
    public Transform shotDir;
    private float timeShot;
    public float startTime;
    public AudioClip Fire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
                GetComponent<AudioSource>().PlayOneShot(Fire);
            }
        }
        else
        {
            timeShot -= Time.deltaTime;
        }
        if (difference.x > 0 && !facingRight)
            Flip();
        else if (difference.x < 0 && facingRight)
            Flip(); 
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        theScale.y *= -1;
        transform.localScale = theScale;
    }
}
