using UnityEngine;

public class pointFaible : MonoBehaviour
{

	public GameObject objetADetruire;

   private void OnTriggerEnter2D(Collider2D collision) {

   	if(collision.CompareTag("Player")) {

   		/*Destroy(transform.parent.gameObject);*///detruit le parent de weak spot qui ici est escargot (parent dans la liste)
   		Destroy(objetADetruire);
   	}

   }
}
