using UnityEngine;
using UnityEngine.UI;


public class Inventaire : MonoBehaviour
{
    
    public int gemmeCount;
    public static Inventaire instance;//script inventory stocker dans instance

    public Text gemmesCountText;

    private void Awake(){

    	if(instance != null) {
    		Debug.LogWarning("Il y'a + d'1 instance d'inventaire dnas la scène");//Empeche la duplication de script inventaire
    		return;
    	}

    	instance=this;
    }

    public void AddGemmes(int count) {

    	gemmeCount += count;
    	gemmesCountText.text = gemmeCount.ToString();
    }

}
