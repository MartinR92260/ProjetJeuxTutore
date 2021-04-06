using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{


	public int maxHealth = 100;
	public int currentHealth;

	public HealthBar healthBar;

	public bool isInvicible = false;

	public SpriteRenderer graphics;

	public float tempsEntreClignotementInvicibilité = 0.2f;

	public float invicibilityTimeAfterHit = 3f;



 public static PlayerHealth instance;

    private void Awake(){

    	if(instance != null) {
    		Debug.LogWarning("Il y'a + d'1 instance de player dans la scène");//Empeche la duplication de script inventaire
    		return;
    	}

    	instance=this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.O)) {//test dmg -> o = -10 pv
        	TakeDamage(40);
        }
    }

   public void TakeDamage(int damage) {

   		if(!isInvicible) {
    	currentHealth -= damage;
    	healthBar.setHealth(currentHealth);

    	//verification joueur toujours en vie (pv>0)
    	if(currentHealth<=0) {

    		Die();
    		return;//arrete le script ici pour ne pas que le joeur devinne invicible
    	}


    	isInvicible = true;
    	StartCoroutine(InvicibilityFlash());
    	StartCoroutine(HandleinvicibilityDelay());
    	}
    }

    public void Die() {
		Debug.Log("joueur eliminé");
		Deplacements.instance.enabled=false;//bloque mouvement perso
		Deplacements.instance.animator.SetTrigger("DeathTrigger");
		Deplacements.instance.personnageRb.bodyType = RigidbodyType2D.Kinematic;//Change rb du joueur en un rb pas deplacable pour empecher ennemies de pousser notre animation de mort
   		Deplacements.instance.playerCollider.enabled=false;//enlever collider pour que l'ennemi ne se suicide pas sur nore animation de mort
    }

    public void HealPlayer(int amount) {

    	if((currentHealth + amount) > maxHealth) {

    		currentHealth = maxHealth;
    	}

    	else {

    		currentHealth += amount;
    	}

    	
    	healthBar.setHealth(currentHealth);

    }

    public IEnumerator InvicibilityFlash() {

    	while(isInvicible) {

    		graphics.color = new Color(1f, 1f, 1f, 0f);//met alpha a 0 (transparent)
    		yield return new WaitForSeconds(tempsEntreClignotementInvicibilité);//temps entre clignotement
    		graphics.color = new Color(1f, 1f, 1f, 1f);//met alpha a 1 (opaque)
    		yield return new WaitForSeconds(tempsEntreClignotementInvicibilité);//temps entre clignotement en cas de rebouclage

    	}
    }

 	public IEnumerator HandleinvicibilityDelay() {

 		yield return new WaitForSeconds(invicibilityTimeAfterHit);
 		isInvicible = false;
 	}

}
