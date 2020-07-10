using UnityEngine;
using System.Collections;

public class CharacterControllerScript : MonoBehaviour {
public float maxSpeed = 10f;
public float jumpForce = 700f;
bool facingRight = true;
bool grounded = false;
public Transform groundCheck;
public float groundRadius = 0.2f;
public LayerMask whatIsGround;
private Animator anim;
public float move;

// Use this for initialization
void Start () {
anim = GetComponent<Animator>();

}

// Update is called once per frame
void FixedUpdate () {


grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);

move = Input.GetAxis ("Horizontal");
anim.SetBool ("Ground", grounded);
anim.SetFloat ("vSpeed", GetComponent<Rigidbody2D>().velocity.y);
if (!grounded)
return;
anim.SetFloat("Speed", Mathf.Abs(move));

}

void Update(){
if (grounded && (Input.GetKeyDown (KeyCode.W))) {

GetComponent<Rigidbody2D>().AddForce (new Vector2(0f,jumpForce));
}
GetComponent<Rigidbody2D>().velocity = new Vector2 (move * maxSpeed, GetComponent<Rigidbody2D>().velocity.y);

if (move > 0 && !facingRight)
Flip ();
else if (move < 0 && facingRight)
Flip ();



/*if (Input.GetKey(KeyCode.Escape))
{
Application.Quit();
}

if (Input.GetKey(KeyCode.R))
{
Application.LoadLevel(Application.loadedLevel);
}*/


}

void Flip(){
facingRight = !facingRight;
Vector3 theScale = transform.localScale;
theScale.x *= -1;
transform.localScale = theScale;
}
}