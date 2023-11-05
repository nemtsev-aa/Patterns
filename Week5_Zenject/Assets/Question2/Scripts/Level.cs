using System;
using UnityEngine;

namespace Question2 {
    public class Level {
        public event Action Defeat;

        public void Start() {
            //Логика старта 
            Debug.Log("Старт");
        }

        public void Restart() {
            //логика очистки уровня
            Start();
        }

        public void OnDefeat() {
            //Логика остановки игры
            Defeat?.Invoke();
        }
    }
}