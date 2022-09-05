using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    /// <summary>
    /// All functions in this script are called by Animation Events
    /// </summary>

    [SerializeField] Collider weaponCollider;

    public void EnableWeapon()
    {
        weaponCollider.enabled = true;
    }

    public void DisableWeapon()
    {
        weaponCollider.enabled = false;
    }
}
