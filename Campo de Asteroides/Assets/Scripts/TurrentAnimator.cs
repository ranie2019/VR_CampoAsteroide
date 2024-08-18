using UnityEngine;

public class TurrentAnimator : MonoBehaviour
{
    // Refer�ncias aos Animators que controlam as anima��es da torre
    public Animator turretAnimator1;
    public Animator turretAnimator2;

    // Vari�vel para controlar a ativa��o dos Animators
    public bool animatorsEnabledOnStart = false;

    private void Start()
    {
        // Desativa os Animators no in�cio
        SetAnimatorsEnabled(false);
    }

    // M�todo p�blico para acionar as anima��es de disparo em ambos os Animators
    public void PlayFireAnimation()
    {
        if (turretAnimator1 != null && turretAnimator2 != null)
        {
            // Verifica se os Animators est�o ativados antes de tentar acionar a anima��o
            if (turretAnimator1.enabled && turretAnimator2.enabled)
            {
                turretAnimator1.SetTrigger("Fire");
                turretAnimator2.SetTrigger("Fire");
            }
        }
    }

    // M�todo p�blico para ativar os Animators
    public void EnableAnimators()
    {
        SetAnimatorsEnabled(true);
    }

    // M�todo privado para ativar ou desativar os Animators
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
