﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MainMenu : MonoBehaviour {

    public TMP_Dropdown dropDown;

    void Start()
    {
        dropDown.onValueChanged.AddListener(ChangeExperimentPart);
    }

    public void StartExperiment(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void quitApplication()
    {
        //TODO Exit app
        Debug.Log("Application exit");
    }

    public void ChangeExperimentPart(int index)
    {
        string selectedValue = dropDown.options[dropDown.value].text;
        Debug.Log(selectedValue);

        string effectTranslated = ExperimentEffects.getInstance().GetValue(selectedValue);
        Debug.Log(effectTranslated);

        ExperimentRunParameters.settings.experimentEffect = effectTranslated;
    }


    public void LoadExperimentDetails()
    {
        var experiment = new ExperimentSettings();
        experiment.sceneNumber = 1;
        experiment.Save("experiment.xml");
        
        var settings = ExperimentSettings.Load("experiment.xml");
        
        if(settings == null) Debug.LogError("File not found.");
        
        //TODO: Zkontrolovat důležité údaje

        ExperimentRunParameters.settings = settings;
    }

    public void SaveAndLoadTest(string filename)
    {
        var result = new ExperimentResult();
        var question = new Question();
        question.questionText = "Which of the two objects is more appealing to you?";
        question.AddLeftRightUndecidedOptions();
        result.questions.Add(question);

        result.Save(filename);
        
        Debug.Log("Saved");
        
        var loaded = new ExperimentResult();
        loaded = ExperimentResult.Load(filename);
        
        Debug.Log("Start: " + loaded.experimentStartTime);
        Debug.Log("End: " + loaded.experimentEndTime);
        Debug.Log("QuestionSetSize: " + loaded.questions.Count);
        
    }
}
