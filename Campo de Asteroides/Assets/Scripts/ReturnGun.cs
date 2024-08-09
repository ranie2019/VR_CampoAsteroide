using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ReturnGun : MonoBehaviour
{
    [Header("Configurações de Posição Original")]
    [Tooltip("Posição e rotação originais da arma.")]
    [SerializeField] private Pose originPose;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        // Inicializa o XRGrabInteractable
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Salva a posição e rotação originais da arma
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
        // Remove o listener quando o objeto é desativado
        grabInteractable.selectExited.RemoveListener(OnGunReleased);
    }

    /// <summary>
    /// Chamado quando a arma é solta pelo jogador.
    /// </summary>
    /// <param name="arg0">Argumentos do evento de soltura.</param>
    private void OnGunReleased(SelectExitEventArgs arg0)
    {
        // Retorna a arma à posição e rotação originais
        transform.SetPositionAndRotation(originPose.position, originPose.rotation);
    }
}
