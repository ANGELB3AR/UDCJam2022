using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    [SerializeField] Collider weaponCollider;

    public void EnableWeapon()
    {
        weaponCollider.enabled = true;
        Debug.Log("Weapon enabled");
    }

    public void DisableWeapon()
    {
        weaponCollider.enabled = false;
    }
}
