using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumperJump : MonoBehaviour
{
    public float bumperForce = 10f;
    public bool utilisé = false;

    public Animator animator;


     
     void OnCollisionEnter2D(Collision2D col) {

         /*ContactPoint2D[] otherObjects = col.contacts;
         foreach(ContactPoint2D contact in otherObjects) 
         {
             var norm = contact.normal;
             col.rigidbody.velocity = Vector2.zero;
             contact.rigidbody.AddForce( -1 * norm * bumperForce,  ForceMode2D.Impulse);
             utilisé=true;


  		

         }  */

/*         Deplacements.instance.personnageRb.velocity= Vector2.up * Deplacements.instance.jump ;
*/         Deplacements.instance.personnageRb.AddForce(new Vector2(0f,Deplacements.instance.jump)*bumperForce);
           utilisé=true;

      		animator.SetBool("utilisé",utilisé);



     }


}
