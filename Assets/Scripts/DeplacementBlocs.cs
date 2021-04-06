using UnityEngine;

public class DeplacementBlocs : MonoBehaviour
{
    public float speed;
	public Transform[] waypoints; // Zone ou l'ennemie va se deplacer

	private Transform target;// devient le waypoints opposé a celui actuelle

	private int destPoint = 0;

	public SpriteRenderer graphics;


	 void Start()
    {
        target = waypoints[0];// par defaut on se deplace vers le 1 waypoints de la liste
    }

    void Update()
    {
        
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime, Space.World);// normalized met la taile de vecteur a 1

        if (Vector3.Distance(transform.position, target.position) < 0.3f) { // Si distance entre ennemie et la ou il va < 0.3f il change de destination

        	destPoint = (destPoint +1) % waypoints.Length;
        	target = waypoints[destPoint];
        	graphics.flipX = !graphics.flipX;
        }

    }
}
