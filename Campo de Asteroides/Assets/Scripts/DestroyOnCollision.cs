using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destrói o objeto que possui este script
        Destroy(gameObject);
    }
}
