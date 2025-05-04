using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
            gameObject.tag = "Hit";
        }
       
    }
}
