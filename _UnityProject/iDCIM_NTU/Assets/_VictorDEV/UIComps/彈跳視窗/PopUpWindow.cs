using System;
using System.Linq;
using UnityEngine;

namespace VictorDev.Advanced
{
    public abstract class PopUpWindow : MonoBehaviour
    {
        protected void ToShow()
        {
            gameObject.SetActive(true);
            BlackScreen?.SetActive(true);
        }

        public void ToClose()
        {
            gameObject.SetActive(false);
            BlackScreen?.SetActive(false);
        }

        protected virtual void OnEnable() => ToShow();

        protected virtual  void OnDisable() => ToClose();

        private GameObject BlackScreen => _blackScreen ??= transform.parent.Find("BlackScreen").gameObject;
        private GameObject _blackScreen;
    }
}