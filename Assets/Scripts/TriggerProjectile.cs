using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
               foreach(GameObject gameObject in gameObjects)
               {
                   gameObject.SetActive(true);
                   DestroytriggerVolume();                
               }       
    }   

    void DestroytriggerVolume()
        {
               Destroy(gameObject);
               gameObject.SetActive(false);
        }
              
    }
}