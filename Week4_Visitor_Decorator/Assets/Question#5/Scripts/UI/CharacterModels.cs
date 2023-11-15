using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterModels : MonoBehaviour {
    [SerializeField] private Races _race;
    [SerializeField] private Specializations _specialization;

    private Races _selectRace;
    private Specializations _selectionSpecialization;

    [field: SerializeField] public List<Model> Models { get; private set; }
    [field: SerializeField] public Model SelectionModel { get; private set; }

    private void Start() {
        _selectRace = _race;
        _selectionSpecialization = _specialization;

        SelectModel();
    }

    private void Update() {
        CangeRace();
        CangeSpecialization();
    }

    private void CangeSpecialization() {
        if (_specialization == _selectionSpecialization)
            return;

        _selectionSpecialization = _specialization;
        SelectModel();
    }

    private void CangeRace() {
        if (_race == _selectRace)
            return;

        _selectRace = _race;
        SelectModel();
    }

    private void SelectModel() {
        if (SelectionModel != null) 
            SelectionModel.gameObject.SetActive(false);


        SelectionModel = Models.FirstOrDefault(model => model.Race == _selectRace && model.Specialization == _selectionSpecialization);
        SelectionModel.gameObject.SetActive(true);
    }
}
