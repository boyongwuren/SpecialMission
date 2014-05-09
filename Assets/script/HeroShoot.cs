using UnityEngine;
using System.Collections;

public class HeroShoot : MonoBehaviour 
{

	private Animator animator;

	// Use this for initialization
	void Start () 
	{
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		bool isDownShoot = Input.GetKeyDown (KeyCode.J);
		bool isDownUp = Input.GetKeyDown (KeyCode.W);

		if (isDownShoot) 
		{
			animator.SetTrigger(Contant.Animator_isShoot);
		} 

		if(isDownUp)
		{
			animator.SetFloat(Contant.Animator_isShootUp,1.5f);
		}else
		{
			animator.SetFloat(Contant.Animator_isShootUp,0.5f);
		}

	}
}
