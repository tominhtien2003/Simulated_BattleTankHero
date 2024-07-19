using System.Collections;
using UnityEngine;
[RequireComponent(typeof(StateMachine))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform bulletHolder;
    [SerializeField] float moveSpeedEnemy;
    [SerializeField] float attackCooldown;

    private Rigidbody rb;
    private StateMachine enemyStateMachine;
    private Vector3[] directionArray;
    private bool isChangingDirection = false;
    private void Awake()
    {
        InitDirections();

        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        enemyStateMachine = GetComponent<StateMachine>();

        enemyStateMachine.ChangeState(new EnemyMoveState(this));

        InvokeRepeating(nameof(HandleAttackEnemy), 1f, attackCooldown);

        BulletManager.Instance.amountEnemy++;
    }
    private void Update()
    {

    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name != "Plane")
        {
            enemyStateMachine.ChangeState(new EnemyChangeDirectionState(this));
        }
    }
    private void InitDirections()
    {
        directionArray = new Vector3[4];

        directionArray[0] = Vector3.forward;

        directionArray[1] = -Vector3.forward;

        directionArray[2] = Vector3.right;

        directionArray[3] = -Vector3.right;
    }
    #region Handle Change Direction Enemy
    public void HandleChangeDirectionEnemy()
    {
        if (isChangingDirection) return;

        StartCoroutine(IEHandleChangeDirectionEnemy());
    }

    private IEnumerator IEHandleChangeDirectionEnemy()
    {
        HandleIdleEnemy();

        isChangingDirection = true;

        int id = UnityEngine.Random.Range(0, directionArray.Length);

        transform.forward = directionArray[id];

        yield return new WaitForSeconds(.5f);

        enemyStateMachine.ChangeState(new EnemyMoveState(this));

        isChangingDirection = false;
    }
    #endregion
    #region Handle Movement Enemy
    public void HandleMovementEnemy()
    {
        rb.velocity = transform.forward * moveSpeedEnemy;
    }
    #endregion
    #region Handle Attack Enemy
    public void HandleAttackEnemy()
    {
        StartCoroutine(IEHandleAttackEnemy());
    }
    private IEnumerator IEHandleAttackEnemy()
    {
        HandleIdleEnemy();

        BulletManager.Instance.DropingSmokeWhenShoot(bulletHolder);

        Transform transformBullet = ObjectPooler.Instance.SpawnObject("BulletEnemy", bulletHolder.position, bulletHolder.rotation);

        yield return new WaitForSeconds(attackCooldown);
    }
    #endregion
    #region Handle Idle Enemy
    public void HandleIdleEnemy()
    {
        rb.velocity = Vector3.zero;
    }
    #endregion
}
