using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    /// <summary>
    /// All functions in this script are called by Animation Events
    /// </summary>

    [SerializeField] Collider weaponCollider;
    [SerializeField] GameObject areaOfEffect = null;
    [SerializeField] float AOETime = 2.5f;

    GameObject AOEInstance;

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
        AOEInstance = Instantiate(areaOfEffect, transform.position, Quaternion.identity);
        StartCoroutine(AOETimer());
    }

    void DisableAOE()
    {
        Destroy(AOEInstance);
    }

    IEnumerator AOETimer()
    {
        yield return new WaitForSeconds(AOETime);
        DisableAOE();
    }
}
