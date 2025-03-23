using UnityEngine;
using System.Collections;

public class ProjectileParticle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(ParticleCountdown());
    }
    private IEnumerator ParticleCountdown()
    {
        yield return new WaitForSeconds(5);
        DestroyParticles();
    }

    private void DestroyParticles()
    {
        Destroy(gameObject);
    }

}
