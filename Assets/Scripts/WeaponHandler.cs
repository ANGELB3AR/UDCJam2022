using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    /// <summary>
    /// All functions in this script are called by Animation Events
    /// </summary>

    [SerializeField] Collider weaponCollider;
    [SerializeField] Collider areaOfEffect = null;
    [SerializeField] ParticleSystem AOEParticles = null;

    ParticleSystem particleInstance;

    public void EnableWeapon()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeapon()
    {
        weaponCollider.enabled = false;
    }

    public void EnableAOE()
    {
        areaOfEffect.enabled = true;
        ActivateAOEParticles();
    }

    public void DisableAOE()
    {
        areaOfEffect.enabled = false;
        DeactivateAOEParticles();
    }

    void ActivateAOEParticles()
    {
        particleInstance = Instantiate(AOEParticles, areaOfEffect.transform);
    }

    void DeactivateAOEParticles()
    {
        Destroy(particleInstance);
    }
}
