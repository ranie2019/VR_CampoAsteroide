using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnGun : MonoBehaviour
{
    [Header("Configura��es de Posi��o Original")]
    [Tooltip("Posi��o e rota��o originais da arma.")]
    [SerializeField] private Pose originPose;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        // Inicializa o XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Salva a posi��o e rota��o originais da arma
        originPose.position = transform.position;
        originPose.rotation = transform.rotation;
    }

    private void OnEnable()
    {
        // Adiciona o listener para o evento de soltura
        grabInteractable.selectExited.AddListener(OnGunReleased);
    }

    private void OnDisable()
    {
        // Remove o listener quando o objeto � desativado
        grabInteractable.selectExited.RemoveListener(OnGunReleased);
    }

    /// <summary>
    /// Chamado quando a arma � solta pelo jogador.
    /// </summary>
    /// <param name="arg0">Argumentos do evento de soltura.</param>
    private void OnGunReleased(SelectExitEventArgs arg0)
    {
        // Retorna a arma � posi��o e rota��o originais
        transform.SetPositionAndRotation(originPose.position, originPose.rotation);
    }
}
