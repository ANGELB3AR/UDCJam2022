using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    [SerializeField] float AOETime = 2.5f;

    private void Start()
    {
        StartCoroutine(AOETimer());
    }

    void DisableAOE()
    {
        Destroy(gameObject);
    }

    IEnumerator AOETimer()
    {
        yield return new WaitForSeconds(AOETime);
        DisableAOE();
    }
}
