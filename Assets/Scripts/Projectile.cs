using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject hitParticles;
    /// <summary>
    /// When script is run it will wait 3 seconds before it runs the destroy function
    /// </summary>
    private void Start()
    {
        Invoke("DestroyProjectile", 3);
    }

    /// <summary>
    /// This is the function that will destroy the projectile
    /// </summary>
    public void DestroyProjectile()
    {
        Destroy(gameObject);
        GameObject particles = Instantiate(hitParticles, transform.position, transform.rotation);
    }

    /// <summary>
    /// This will activate the destroy function early if it collides with something
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            collision.gameObject.GetComponentInChildren<Renderer>().material.color = Color.red; //Create Array
            Destroy(collision.gameObject, 1);
        }
        DestroyProjectile();
    }
}