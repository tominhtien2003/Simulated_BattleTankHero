using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private float speedSwipeScreen = 1.0f;
    [SerializeField] private float decelerationRate = 0.1f;

    private Camera cameraMain;
    private Vector3 lastPosition;
    private Vector3 swipeVelocity;

    private void Start()
    {
        cameraMain = Camera.main;
        lastPosition = Vector3.zero;
        swipeVelocity = Vector3.zero;
    }

    private void Update()
    {
        HandleScreenWhenSwipe();
    }

    private void HandleScreenWhenSwipe()
    {
        if (Input.GetMouseButton(0))
        {
            DoSwipe();
        }
        else
        {
            ApplyDeceleration();
        }
    }

    private void DoSwipe()
    {
        Vector3 currentPosition = Input.mousePosition;

        if (lastPosition != Vector3.zero)
        {
            Vector3 directionSwipe = (lastPosition - currentPosition).normalized;
            directionSwipe.y = 0f;

            swipeVelocity = directionSwipe * speedSwipeScreen;

            cameraMain.transform.position += swipeVelocity * Time.deltaTime;
        }
        lastPosition = currentPosition;
    }

    private void ApplyDeceleration()
    {
        if (swipeVelocity.sqrMagnitude > 0.001f)
        {
            cameraMain.transform.position += swipeVelocity * Time.deltaTime;
            swipeVelocity *= (1f - decelerationRate * Time.deltaTime);
        }
        else
        {
            swipeVelocity = Vector3.zero;
        }
    }
    public void ReturnButton()
    {
        SceneManager.LoadScene(0);
    }
}
