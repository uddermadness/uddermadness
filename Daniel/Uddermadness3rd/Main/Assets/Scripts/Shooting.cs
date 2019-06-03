using UnityEngine; 
using System.Collections;
 
 public class Shooting : MonoBehaviour 
 {
    public float bulletSpeed = 10;
    public Rigidbody bullet;
    public Transform bulletSpawnPoint;

    public Inventory inventory;
    
    public int maxAmmo = 50;
    private int currentAmmo = -1;
    public float reloadTime = 1f;
    private bool isReloading = false;
     
    //public Transform bulletSpawner;

    void Start ()
    {
        if (currentAmmo == -1)
        currentAmmo = maxAmmo;
    }

    void OnEnable ()
    {
        isReloading = false;  
    }
     
    void Fire()
    {
        currentAmmo--;
        
        Rigidbody bulletClone = Instantiate<Rigidbody>(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        // bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update () 
    {
        transform.eulerAngles = Camera.main.transform.eulerAngles;

        if (isReloading)
            return;

        if (currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButton("Fire1"))
            Fire();
    }

    public void AddBullets(string name)
    {
        Debug.Log("Picked up " + name);
    }

    IEnumerator Reload ()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime - .25f);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
 }
