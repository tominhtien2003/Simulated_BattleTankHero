using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(StateMachine))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] Transform bulletHolder;
    [SerializeField] float attackCooldown;
    [SerializeField] float moveSpeedPlayer;

    private Vector3 lastMousePosition;
    private Vector3 currentMousePosition;

    public StateMachine playerStateMachine { get; private set; }
    private Rigidbody rb;
    private bool isRotatingPlayer = false;
    private bool isAttackingPlayer = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        playerStateMachine = GetComponent<StateMachine>();

        playerStateMachine.ChangeState(new PlayerMoveState(this));
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            currentMousePosition = Input.mousePosition;

            if (lastMousePosition == Vector3.zero)
            {
                lastMousePosition = currentMousePosition;
            }
            else if (lastMousePosition != currentMousePosition)
            {
                playerStateMachine.ChangeState(new PlayerChangeDirectionState(this));
            }
            else
            {
                playerStateMachine.ChangeState(new PlayerAttackState(this));
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            ResetMousePointer();

            playerStateMachine.ChangeState(new PlayerMoveState(this));
        }

    }
    private void ResetMousePointer()
    {
        lastMousePosition = currentMousePosition = Vector3.zero;
    }
    #region HandleMovement Player
    public void HandleMovementPlayer()
    {
        rb.velocity = moveSpeedPlayer * transform.forward;
    }
    #endregion
    #region Handle Attack
    public void HandleAttack()
    {
        if (isAttackingPlayer) return;

        StartCoroutine(IEHandleAttack());
    }
    private IEnumerator IEHandleAttack()
    {
        isAttackingPlayer = true;

        BulletManager.Instance.DropingSmokeWhenShoot(bulletHolder);

        Transform transformBullet = ObjectPooler.Instance.SpawnObject("BulletPlayer", bulletHolder.position, bulletHolder.rotation);

        yield return new WaitForSeconds(attackCooldown);

        isAttackingPlayer = false;
    }
    #endregion
    #region Handle Change direction
    public void HandleChangeDirection()
    {
        if (lastMousePosition == currentMousePosition || isRotatingPlayer) return;

        StartCoroutine(IEHandleChangeDirection());
    }
    private IEnumerator IEHandleChangeDirection()
    {
        HandleIdleStatePlayer();

        isRotatingPlayer = true;

        Vector3 swipeDirection = (currentMousePosition - lastMousePosition).normalized;

        float convertToAngle = Mathf.Atan2(swipeDirection.y, swipeDirection.x) * Mathf.Rad2Deg;

        Vector3 rotateDirection = GetDirectionFromAngle(convertToAngle);

        transform.forward = rotateDirection;

        lastMousePosition = currentMousePosition;

        yield return new WaitForSeconds(Time.deltaTime);

        playerStateMachine.ChangeState(new PlayerMoveState(this));

        isRotatingPlayer = false;
    }
    private Vector3 GetDirectionFromAngle(float angle)
    {
        Vector3 direction = Vector3.zero;

        if (angle > -45 && angle <= 45f)
        {
            direction = Vector3.right;
        }
        else if (angle <= 135f && angle > 45f)
        {
            direction = Vector3.forward;
        }
        else if (angle <= -45f && angle >= -135f)
        {
            direction = -Vector3.forward;
        }
        else
        {
            direction = -Vector3.right;
        }
        return direction;
    }
    #endregion
    #region Handle Idle state
    public void HandleIdleStatePlayer()
    {
        rb.velocity = Vector3.zero;
    }
    #endregion
}
