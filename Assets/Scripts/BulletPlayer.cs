using UnityEngine;

public class BulletPlayer : IBaseBullet
{
    [SerializeField] float damage;
    [SerializeField] float initialSpeedBullet;
    [SerializeField] float acceleration;
    [SerializeField] float maxSpeed;
    [SerializeField] float timeLife;

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
            HealthEnemy healthEnemy = other.GetComponentInParent<HealthEnemy>();

            if (healthEnemy != null)
            {
                healthEnemy.OnDeathEnemy += HealthEnemy_OnDeathEnemy;

                healthEnemy.TakeDamage(damage);

                healthEnemy.OnDeathEnemy -= HealthEnemy_OnDeathEnemy;
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
