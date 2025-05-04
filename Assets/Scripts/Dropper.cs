using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] float timetoWait = 3f;

    void Start()
    {
        
    }

    void Update()
    {
         if (Time.time > timetoWait)
         {
             Debug.Log("Lookout Below!");
         }
    }
}
