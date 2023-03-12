using UnityEngine;
using TMPro;
using Locations.Objects;

namespace Interfaces.Displays
{
    public class CoinDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _coinDisplayText = null;

        private int _coinValue;


        #region MONO

        private void Awake() => _coinDisplayText = GetComponent<TextMeshProUGUI>();

        private void Start() => UpdateCoinDisplay();

        private void OnEnable() => Crystal.OnTake += TakeValue;

        private void OnDisable() => Crystal.OnTake -= TakeValue;

        #endregion

        #region Private Methods

        private void TakeValue(int value)
        {
            _coinValue += value;

            UpdateCoinDisplay();
        }

        private void UpdateCoinDisplay()
        {
            _coinDisplayText.text = _coinValue.ToString();
        }

        #endregion
    }
}