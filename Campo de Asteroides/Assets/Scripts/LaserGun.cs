using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [Header("Configurações do Laser")]
    [Tooltip("Animator responsável pela animação de disparo.")]
    [SerializeField] private Animator laserAnimator;

    [Header("Som do Disparo")]
    [Tooltip("Som reproduzido ao disparar o laser.")]
    [SerializeField] private AudioClip laserSFX;

    [Header("Origem do Raycast")]
    [Tooltip("Transform de onde o raycast será emitido.")]
    [SerializeField] private Transform raycastOrigin;

    private AudioSource laserAudioSource;
    private RaycastHit hit;

    private void Awake()
    {
        // Tenta obter o AudioSource automaticamente ou adiciona um novo
        laserAudioSource = GetComponent<AudioSource>();
        if (laserAudioSource == null)
        {
            laserAudioSource = gameObject.AddComponent<AudioSource>();
        }

        // Atribui o AudioClip ao AudioSource e configura as propriedades do som
        if (laserSFX != null)
        {
            laserAudioSource.clip = laserSFX;
            laserAudioSource.playOnAwake = false;
        }
    }

    public void LaserGunFire()
    {
        // Ativa a animação de disparo, se atribuída
        if (laserAnimator != null)
        {
            laserAnimator.SetTrigger("Fire");
        }

        // Reproduz o som de disparo
        if (laserAudioSource != null && laserSFX != null)
        {
            laserAudioSource.Play();
        }

        // Executa o Raycast a partir da origem definida
        if (raycastOrigin != null && Physics.Raycast(raycastOrigin.position, raycastOrigin.forward, out hit, 800f))
        {
            // Verifica se o objeto atingido possui o script AsteroidHit
            AsteroidHit asteroidHit = hit.transform.GetComponent<AsteroidHit>();
            if (asteroidHit != null)
            {
                asteroidHit.AsteroidDestroyed();
            }
        }
    }
}
