using UnityEngine;
using System.Collections;

public class HeroMoveControl : MonoBehaviour {

	public int moveSpeed = 500;

	public int maxVelocity = 5;

	public int jumpForce = 5000;

	private Animator animator;

	private bool isToRight = false; 

	private bool isGround = true;
	

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		flip ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//isGround = Physics2D.Linecast (transform.position,ground.position,1<<LayerMask.NameToLayer("Ground"));

		//if(Input.GetAxis (Contant.Vertical)>0 && isGround)
		//	jump = true;

		//isGround = false;

		//print ("Update");
	}

 



	void OnCollisionEnter2D(Collision2D coll) 
	{
		if(LayerMask.LayerToName(coll.gameObject.layer) == "Ground")
		{
			isGround = true;
		}
	}





	void FixedUpdate()
	{
		//print ("FixedUpdate");

		float h = Input.GetAxis (Contant.Horizontal);
		float v = Input.GetAxis (Contant.Vertical);
		 
		if(h!=0)
		{
			//run animation
			animator.SetBool(Contant.Animator_isRun,true);

			rigidbody2D.AddForce (h/Mathf.Abs(h)*transform.right*moveSpeed);

			if (Mathf.Abs (rigidbody2D.velocity.x) > maxVelocity) 
			{ 
				rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x/Mathf.Abs (rigidbody2D.velocity.x)*maxVelocity,rigidbody2D.velocity.y);
			}

			if(h>0&&isToRight == false)
			{
				//to right
				flip();
			}
			
			if(h<0&&isToRight == true)
			{
				//to left
				flip();
			}

		}else
		{
			//stand animation
			animator.SetBool(Contant.Animator_isRun,false);
		}


		if(v>0 && isGround)
		{
			//jump
			isGround = false;
			rigidbody2D.AddForce (new Vector2(0f, jumpForce));  
			//animator.SetTrigger(Contant.Animator_isJump);
			//animator.SetBool(Contant.Animator_isJump,true);
		}
 
		//if(jump)
		//{
		//	print("jump --------------------------");
			// Add a vertical force to the player.
		///	rigidbody2D.AddForce(new Vector2(0f, jumpForce));
			
			// Make sure the player can't jump again until the jump conditions from Update are satisfied.
		//	jump = false;
		//}

	}

	void flip()
	{
		isToRight = !isToRight;

		Vector3 vec = transform.localScale;
		vec.x *= -1;
		transform.localScale = vec;
	}

 
}
