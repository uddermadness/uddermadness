using UnityEngine; 
using System.Collections;
 
 public class Shooting : MonoBehaviour 
 {
    public float bulletSpeed = 10;
    public Rigidbody[] bullet;
    public int currentBullet;
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

        currentBullet = 0;

        // Debug.Log(inventory.items[0].item);
        // Debug.Log(inventory.items[0].count);
        // Debug.Log(inventory.items[1].item);
        // Debug.Log(inventory.items[1].count);
        // Debug.Log(inventory.items[2].item);
        // Debug.Log(inventory.items[2].count);
        
    }
    

    void OnEnable ()
    {
        isReloading = false;  
    }
     
    void Fire()
    {
        currentAmmo--;
        if (currentBullet > 0)
        {
            inventory.items[currentBullet - 1].count = currentAmmo;
        }
        
        Rigidbody bulletClone = Instantiate<Rigidbody>(bullet[currentBullet], bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        // bulletClone.velocity = transform.forward * bulletSpeed;
    }

    void Update () 
    {
        transform.eulerAngles = Camera.main.transform.eulerAngles;

        // if (isReloading)
        //     return;
        // using if statements to check which bullet is selected and how ammo is left
        // if the ammo runs out the ammo type is set back to the default milk
        // to change ammo the player has to choose from 1(milk default),2(ice),3(pepper),4(slime)
        if (currentAmmo <= 0)
        {
            // StartCoroutine(Reload());
            // return;
            currentBullet = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentBullet = 0;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentBullet = 1;
            currentAmmo = inventory.items[currentBullet - 1].count;
            if (currentAmmo == 0)
            {
                currentBullet = 0;
                //Debug.Log("DefaultBullet");
            }
            //Debug.Log(currentAmmo + "ice");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentBullet = 2;
            currentAmmo = inventory.items[currentBullet - 1].count;
            if (currentAmmo == 0)
            {
                currentBullet = 0;
                //Debug.Log("DefaultBullet");
            }
           //Debug.Log(currentAmmo + "pepper");
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentBullet = 3;
            currentAmmo = inventory.items[currentBullet - 1].count;
            //Debug.Log(currentAmmo + "slime");
        }
        // firing bullets on left click
        if (Input.GetButton("Fire1"))
            Fire();
    }
    //adding bullets to the inventory
    public void AddBullets(string name)
    {
        Debug.Log("Picked up " + name);
    }

    // IEnumerator Reload ()
    // {
    //     isReloading = true;
    //     Debug.Log("Reloading...");

    //     yield return new WaitForSeconds(reloadTime - .25f);

    //     currentAmmo = maxAmmo;
    //     isReloading = false;
    // }
 }
