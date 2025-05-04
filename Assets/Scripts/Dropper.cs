using UnityEngine;

public class Dropper : MonoBehaviour
{

    [SerializeField] float timetoWait = 3f;

    MeshRenderer myMeshRenderer;
    Rigidbody myRigidbody;

    void Start()
    {
        myMeshRenderer = GetComponent<MeshRenderer>();
        myMeshRenderer.enabled = false;
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.useGravity = false;
    }

    void Update()
    {
         if (Time.time > timetoWait)
         {
            myMeshRenderer.enabled = true;
            myRigidbody.useGravity = true;
         }
    }
}
