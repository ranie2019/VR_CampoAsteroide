using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [Header("Configura��es do Laser")]
    [Tooltip("Animator respons�vel pela anima��o de disparo.")]
    [SerializeField] private Animator laserAnimator;

    [Header("Som do Disparo")]
    [Tooltip("Som reproduzido ao disparar o laser.")]
    [SerializeField] private AudioClip laserSFX;

    [Header("Configura��es da Bala")]
    [Tooltip("Prefab da bala que ser� instanciada ao disparar.")]
    [SerializeField] private GameObject bulletPrefab;

    [Tooltip("Velocidade da bala disparada.")]
    [SerializeField] private float bulletSpeed = 20f;

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
        // Ativa a anima��o de disparo, se atribu�da
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
        if (bulletPrefab != null)
        {
            // Instancia a bala na posi��o e dire��o da arma
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            // Aplica uma for�a na bala para mov�-la para frente
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity = transform.forward * bulletSpeed;
            }
            else
            {
                Debug.LogError("A bala n�o possui um Rigidbody!");
            }
        }
        else
        {
            Debug.LogError("bulletPrefab n�o est� atribu�do!");
        }
    }
}
