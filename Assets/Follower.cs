using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follower : MonoBehaviour{



  public Animator animator;
  
  GameObject player;

  public Transform target;

  Rigidbody2D myRigidbody;

  public float range = 2f;
  public float moveSpeed = 2f;



void Start()
{
    player = GameObject.FindGameObjectWithTag("Player");
    myRigidbody = GetComponent<Rigidbody2D>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

}

void Update()
{

    if(IsPlayerInRange(range) )
    {
        Follow();
    }
    else {
  
    this.myRigidbody.velocity = Vector3.zero;//Stop le mouvement
 	 }
 	 animator.SetBool("inEnnemyVis",IsPlayerInRange(range));//check si animation est la bonne a chaque frame

}

private bool IsPlayerInRange(float range)
{
    return Vector3.Distance(transform.position, player.transform.position) <= range;//calcule la distance entre le joueur et lui même

}


void Follow()
{
	transform.LookAt(target.position);//regarde le joueur
    transform.Rotate(new Vector3(0,-90,0),Space.Self);
    transform.Translate(new Vector3(moveSpeed* Time.deltaTime,0,0) );//Deplacement

}
}
