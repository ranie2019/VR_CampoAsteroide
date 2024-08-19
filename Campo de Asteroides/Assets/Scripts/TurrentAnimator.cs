using UnityEngine;

public class TurrentAnimator : MonoBehaviour
{
    [Header("Animators")]
    [Tooltip("Referências aos Animators que controlam as animações da torre.")]
    [SerializeField] private Animator turretAnimator1;
    [SerializeField] private Animator turretAnimator2;

    // Método público para ativar a animação de disparo
    public void ActivateFireAnimation()
    {
        if (turretAnimator1 != null)
        {
            turretAnimator1.SetBool("Laser", true);
        }

        if (turretAnimator2 != null)
        {
            turretAnimator2.SetBool("Laser", true);
        }
    }

    // Método público para desativar a animação de disparo
    public void DeactivateFireAnimation()
    {
        if (turretAnimator1 != null)
        {
            turretAnimator1.SetBool("Laser", false);
        }

        if (turretAnimator2 != null)
        {
            turretAnimator2.SetBool("Laser", false);
        }
    }
}
