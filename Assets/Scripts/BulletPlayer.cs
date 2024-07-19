using UnityEngine;

public class BulletPlayer : BaseBullet
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
        BulletManager.Instance.ExplosionBoom(transform);

        AudioManager.Instance.PlayVFX("Explosion");

        if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            IBaseHealth healthEnemy = other.GetComponentInParent<HealthEnemy>();

            if (healthEnemy != null)
            {
                healthEnemy.OnDeath += HealthEnemy_OnDeathEnemy;

                healthEnemy.TakeDamage(damage);

                healthEnemy.OnDeath -= HealthEnemy_OnDeathEnemy;
            }
        }
        TurnOffBullet();
    }

    private void HealthEnemy_OnDeathEnemy(object sender, System.EventArgs e)
    {
        BulletManager.Instance.amountEnemy--;
    }

    private void TurnOffBullet()
    {
        gameObject.SetActive(false);

        timeLife = 4f;
    }
}
