using UnityEngine;
using TMPro;
using Character.Slingshot;

namespace Interfaces.Displays
{
    public class SlingCountDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _slingCountDisplayText = null;

        private int _slingCountValue;


        #region MONO

        private void Awake() => _slingCountDisplayText = GetComponent<TextMeshProUGUI>();

        private void Start() => UpdateCoinDisplay();

        private void OnEnable() => Player_Slingshot.OnSling += ChangeValue;

        private void OnDisable() => Player_Slingshot.OnSling -= ChangeValue;

        #endregion

        #region Private Methods

        private void ChangeValue(int value)
        {
            _slingCountValue = value;

            UpdateCoinDisplay();
        }

        private void UpdateCoinDisplay()
        {
            _slingCountDisplayText.text = _slingCountValue.ToString();
        }

        #endregion
    }
}