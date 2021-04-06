using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Deplacements : MonoBehaviour
{



        private bool enSaut;
        public bool auSol;//a mettre en private


	    public Rigidbody2D personnageRb;
  	    public float moveSpeed;
        private Vector3 velocity = Vector3.zero;
        public  float jump;

        public Transform groundCheck;
        public float groundCheckRadius;
        public LayerMask collisionLayers;

        public SpriteRenderer spriteRenderer;
        public CapsuleCollider2D playerCollider;

      

        public Animator animator;

        private  float horizontalMovement;

        public static Deplacements instance;

    private void Awake(){

        if(instance != null) {
            Debug.LogWarning("Il y'a + d'1 instance de Deplacement dans la scène");
            return;
        }

        instance=this;
    }

    
    void Update()
    {
                                                                                     
         horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;

        if(Input.GetButtonDown("Jump") && auSol==true) {

            enSaut=true;

        }

       Flip(personnageRb.velocity.x);

       float characterVelocity = Mathf.Abs(personnageRb.velocity.x);//Quand on se deplace vers la gauche met la valeur en absolue et donc en positif
       animator.SetFloat("Speed",characterVelocity);
        
              
    }

    void FixedUpdate()
    {
         auSol = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayers);

       mouvementJoueur(horizontalMovement);

    }

     /*void Update(){

         if(Input.GetButtonDown("Jump") && auSol==true) {

            enSaut=true;

        }
         Flip(personnageRb.velocity.x);

       float characterVelocity = Mathf.Abs(personnageRb.velocity.x);//Quand on se deplace vers la gauche met la valeur en absolue et donc en positif
       animator.SetFloat("Speed",characterVelocity);

     }

    void FixedUpdate(){

        horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        auSol = Physics2D.OverlapCircle(solCheck.position,solCheckRadius, CollisionLayers); 

        mouvementJoueur(horizontalMovement);

    }*/



    /* private void Jumpp()
    {
    	this.personnageRb.velocity = Vector2.up * jump ;
       
    }*/

    void mouvementJoueur(float _horizontalMovement) {

        Vector3 targetVelocity = new Vector2(_horizontalMovement, personnageRb.velocity.y);//Cible vers laquelle on veut diriger le personnage
        personnageRb.velocity = Vector3.SmoothDamp(personnageRb.velocity, targetVelocity, ref velocity, 0.05f/*durée du déplacement*/);
        
        if(enSaut == true) {

            personnageRb.AddForce(new Vector2(0f,jump));
            enSaut=false;
        }

    }

    


    void Flip(float _velocity) { // changement direction

        if(_velocity > 0.1f) {

            spriteRenderer.flipX=false;
        }

        else if(_velocity < -0.1f) {

            spriteRenderer.flipX=true;

        }
    }

    public void OnDrawGizmos() {

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);//check si perso a terre ou dans les airs

    }
}
