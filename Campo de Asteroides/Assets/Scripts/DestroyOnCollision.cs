using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destr�i o objeto que possui este script
        Destroy(gameObject);

        // Opcional: Para depura��o, voc� pode exibir uma mensagem no console
        Debug.Log($"{gameObject.name} colidiu com {collision.gameObject.name} e foi destru�do.");
    }
}
