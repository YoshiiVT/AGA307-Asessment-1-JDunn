using UnityEngine;

public class FiringPoint : GameBehaviour
{
    public GameObject projectilePrefab; //The Projectile we wish the Instantiate
    public float projectileSpeed = 1000f; //The speed our projectile fires at

    public void FireProjectile()
    {
        GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, transform.rotation); //Instantiate our projectile prefab at the firing point
        projectileInstance.GetComponent<Rigidbody>().AddForce(transform.forward * projectileSpeed); //Get the rigidbody component to add force to it
        Destroy(projectileInstance, 5); //Destroy our projectile after 5 seconds
    }
}
