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

    [Header("Configurações da Bala")]
    [Tooltip("Prefab da bala que será instanciada ao disparar.")]
    [SerializeField] private GameObject bulletPrefab;

    [Tooltip("Velocidade da bala disparada.")]
    [SerializeField] private float bulletSpeed = 20f;

    [Header("Ponto de Spawn da Bala")]
    [Tooltip("Transform que define o ponto de spawn da bala.")]
    [SerializeField] private Transform bulletSpawnPoint;

    private AudioSource laserAudioSource;

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

        // Instancia e dispara a bala
        FireBullet();
    }

    private void FireBullet()
    {
        if (bulletPrefab != null && bulletSpawnPoint != null)
        {
            // Instancia a bala no ponto de spawn
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

            // Aplica uma força na bala para movê-la para frente
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = bulletSpawnPoint.forward * bulletSpeed;
            }
        }
        else
        {
            Debug.LogWarning("BulletPrefab ou BulletSpawnPoint não estão atribuídos.");
        }
    }
}
