using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODFix : MonoBehaviour
{
    bool audioResumed = false;

    private void Start()
    {
        ResumeAudio();
    }

    public void ResumeAudio()
    {
        if (!audioResumed)
        {
            var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
            Debug.Log(result);
            result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
            Debug.Log(result);
            audioResumed = true;
        }
    }
}
