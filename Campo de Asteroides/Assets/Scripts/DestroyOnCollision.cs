using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destr�i o objeto que possui este script
        Destroy(gameObject);
    }
}
