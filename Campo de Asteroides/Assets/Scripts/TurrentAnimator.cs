using UnityEngine;

public class TurrentAnimator : MonoBehaviour
{
    // Referências aos Animators que controlam as animações da torre
    public Animator turretAnimator1;
    public Animator turretAnimator2;

    // Variável para controlar a ativação dos Animators
    public bool animatorsEnabledOnStart = false;

    private void Start()
    {
        // Desativa os Animators no início
        SetAnimatorsEnabled(false);
    }

    // Método público para acionar as animações de disparo em ambos os Animators
    public void PlayFireAnimation()
    {
        if (turretAnimator1 != null && turretAnimator2 != null)
        {
            // Verifica se os Animators estão ativados antes de tentar acionar a animação
            if (turretAnimator1.enabled && turretAnimator2.enabled)
            {
                turretAnimator1.SetTrigger("Fire");
                turretAnimator2.SetTrigger("Fire");
            }
        }
    }

    // Método público para ativar os Animators
    public void EnableAnimators()
    {
        SetAnimatorsEnabled(true);
    }

    // Método privado para ativar ou desativar os Animators
    private void SetAnimatorsEnabled(bool enabled)
    {
        if (turretAnimator1 != null)
        {
            turretAnimator1.enabled = enabled;
        }

        if (turretAnimator2 != null)
        {
            turretAnimator2.enabled = enabled;
        }
    }
}
