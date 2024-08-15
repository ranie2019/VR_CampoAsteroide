using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destrói o objeto que possui este script
        Destroy(gameObject);

        // Opcional: Para depuração, você pode exibir uma mensagem no console
        Debug.Log($"{gameObject.name} colidiu com {collision.gameObject.name} e foi destruído.");
    }
}
