using UnityEngine;

public class BulletEnemy : BaseBullet
{
    private float currentSpeedBullet;

    private void OnEnable()
    {
        currentSpeedBullet = initialSpeedBullet;
    }

    private void Update()
    {
        timeLife -= Time.deltaTime;

        if (timeLife <= 0f)
        {
            TurnOffBullet();
        }
        HandleMovementBullet();
    }

    private void HandleMovementBullet()
    {
        currentSpeedBullet = Mathf.Min(currentSpeedBullet + acceleration * Time.deltaTime, maxSpeed);

        transform.position += transform.forward * currentSpeedBullet * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        BulletManager.Instance.ExplosionBoomOfBulletEnemy(transform);

        AudioManager.Instance.PlayVFX("Explosion");

        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            IBaseHealth healthPlayer = other.GetComponentInParent<HealthPlayer>();

            if (healthPlayer != null)
            {
                healthPlayer.OnDeath += HealthPlayer_OnDeathPlayer;

                healthPlayer.TakeDamage(damage);

                healthPlayer.OnDeath -= HealthPlayer_OnDeathPlayer;
            }
        }
        TurnOffBullet();
    }

    private void HealthPlayer_OnDeathPlayer(object sender, System.EventArgs e)
    {
        GameObject.Find("SceneManager").transform.GetChild(0).gameObject.SetActive(true);
    }

    private void TurnOffBullet()
    {
        gameObject.SetActive(false);

        timeLife = 4f;
    }
}
