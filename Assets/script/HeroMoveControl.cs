using UnityEngine;
using System.Collections;

public class HeroMoveControl : MonoBehaviour {

	public int moveSpeed = 500;

	public int maxVelocity = 5;

	public int jumpForce = 5000;

	private Animator animator;

	private bool isToRight = false;

	private bool isJump = false;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
		flip ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	    if(transform.rotation.z != 0)
		{
			//Quaternion rotation = transform.rotation;
		     //rotation.z = 0;
			//transform.rotation = rotation;
		}



	}

	void FixedUpdate()
	{
		float h = Input.GetAxis (Contant.Horizontal);
		float v = Input.GetAxis (Contant.Vertical);
		 
		if(h!=0)
		{
			//run animation
			animator.SetBool(Contant.Animator_isRun,true);

			rigidbody2D.AddForce (h/Mathf.Abs(h)*transform.right*moveSpeed);

			if (Mathf.Abs (rigidbody2D.velocity.x) > maxVelocity) 
			{ 
				//rigidbody2D.velocity = new Vector2(maxVelocity,rigidbody2D.velocity.y);
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


		if(v>0&& isJump == false)
		{
			//jump
			isJump = true;
			rigidbody2D.AddForce (transform.up*jumpForce);  
			//animator.SetTrigger(Contant.Animator_isJump);
			animator.SetBool(Contant.Animator_isJump,true);
		}
 
	}

	void flip()
	{
		isToRight = !isToRight;

		Vector3 vec = transform.localScale;
		vec.x *= -1;
		transform.localScale = vec;
	}

	void jumpOver()
	{
		isJump = false;
		animator.SetBool (Contant.Animator_isJump,false);
	}
}
