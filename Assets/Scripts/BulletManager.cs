using System;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    #region singleton
    private static BulletManager instance;
    public static BulletManager Instance { get { return instance; } }
    #endregion

    public event EventHandler OnAllEnemyDeath;
    [SerializeField] GameObject vfxBoom;
    [SerializeField] GameObject vfxBoom2;
    [SerializeField] GameObject vfxSmokeWhenShoot;

    public int amountEnemy;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        OnAllEnemyDeath += BulletManager_OnAllEnemyDeath;
    }
    private void Update()
    {
       if (amountEnemy == 0)
        {
            OnAllEnemyDeath?.Invoke(this, EventArgs.Empty);
        }
    }

    private void BulletManager_OnAllEnemyDeath(object sender, EventArgs e)
    {
        if (amountEnemy == 0)
        {
            GameObject.Find("SceneManager").transform.GetChild(1).gameObject.SetActive(true);
        }
    }

    public void ExplosionBoom(Transform objParent)
    {
        GameObject objVFXBoomSpawn = Instantiate(vfxBoom);

        objVFXBoomSpawn.transform.position = objParent.position;

        Destroy(objVFXBoomSpawn, 2f);
    }
    public void ExplosionBoomOfBulletEnemy(Transform objParent)
    {
        GameObject objVFXBoomSpawn = Instantiate(vfxBoom2);

        objVFXBoomSpawn.transform.position = objParent.position;

        Destroy(objVFXBoomSpawn, 2f);
    }
    public void DropingSmokeWhenShoot(Transform objParent)
    {
        GameObject objVFXSmokeWhenShootSpawn = Instantiate(vfxSmokeWhenShoot);

        objVFXSmokeWhenShootSpawn.transform.position = objParent.position;

        Destroy(objVFXSmokeWhenShootSpawn, 1f);
    }
}
