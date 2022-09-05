using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatAudio : MonoBehaviour
{
    public void PlayAxeSwing1()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/AxeSwing1", transform.position);
    }

    public void PlayAxeSwing2()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/AxeSwing2", transform.position);
    }

    public void PlayPlayerSwordSwing()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/PlayerSwordSwing", transform.position);
    }

    public void PlayEnemySwordSwing()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/EnemySwordSwings", transform.position);
    }
}
