using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public void ShopButton()
    {
        SceneManager.LoadScene(1);
    }
    public void StartButton()
    {
        SceneManager.LoadScene(2);
    }
    public void ReturnButton()
    {
        BulletManager.Instance.amountEnemy = 0;
        SceneManager.LoadScene(0);
    }
    public void NextMap()
    {
        int nextIndexScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextIndexScene < SceneManager.sceneCountInBuildSettings)
        {
            BulletManager.Instance.amountEnemy = 0;
            SceneManager.LoadScene(nextIndexScene);
        }
    }
    public void PreviousMap()
    {
        int nextIndexScene = SceneManager.GetActiveScene().buildIndex - 1;

        if (nextIndexScene > 1)
        {
            BulletManager.Instance.amountEnemy = 0;
            SceneManager.LoadScene(nextIndexScene);
        }
    }
    public void PlayAgainButton()
    {
        BulletManager.Instance.amountEnemy = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ExitButton()
    {
        BulletManager.Instance.amountEnemy = 0;
        SceneManager.LoadScene(0);
    }
}
