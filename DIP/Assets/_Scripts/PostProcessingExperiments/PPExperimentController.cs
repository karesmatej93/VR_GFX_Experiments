﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using TMPro;

public class PPExperimentController : MonoBehaviour
{
    public PostProcessingProfile processingProfile;
    public Material cameraMetrial;
    public TextMeshPro questionTextDisplay;

    private bool effectEnabled = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("SceneSwap"))
        {
            EffectToggle(ExperimentRunParameters.settings.experimentEffect);
        }
    }

    public void EffectToggle(string effect)
    {
        effectEnabled = !effectEnabled;

        switch (effect)
        {
            case "SSAO":
                processingProfile.ambientOcclusion.enabled = effectEnabled;
                break;
            case "AA":
                processingProfile.antialiasing.enabled = effectEnabled;
                break;
            case "Bloom":
                processingProfile.bloom.enabled = effectEnabled;
                break;
            case "EyeAdapt":
                processingProfile.eyeAdaptation.enabled = effectEnabled;
                break;
        }
    }
}