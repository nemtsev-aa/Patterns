using System;
using UnityEngine;

namespace Question2 {
    public class Level {
        public event Action Defeat;

        public void Start() {
            //������ ������ 
            Debug.Log("�����");
        }

        public void Restart() {
            //������ ������� ������
            Start();
        }

        public void OnDefeat() {
            //������ ��������� ����
            Defeat?.Invoke();
        }
    }
}