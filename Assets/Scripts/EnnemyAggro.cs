using UnityEngine;
 using System.Collections;
 
 public class EnnemyAggro : MonoBehaviour {
 
     public Transform target;
     public float speed = 3f;
     public float distanceDeDétection = 5f;
     public bool inEnnemyVision = false;
 
 	public Animator animator;

     void Start () {
         
     }
 
     void Update(){
         
         
         transform.LookAt(target.position);//regarde le joueur
         transform.Rotate(new Vector3(0,-90,0),Space.Self);
         
         
         //deplacement vers joueurr
         if (Vector3.Distance(transform.position,target.position)>1f && Vector3.Distance(transform.position,target.position)<distanceDeDétection){//se deplace si le joueur est a plus de 1f de distance et moins de 5f
             transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
             inEnnemyVision = true;
         }
         else if(Vector3.Distance(transform.position,target.position)>distanceDeDétection){
         inEnnemyVision=false;
 		}

 		animator.SetBool("inEnnemyVis",inEnnemyVision);
     }
 
 }