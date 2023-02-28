using UnityEngine;

namespace Enemies
{
    public class Enemy_Attack : MonoBehaviour
    {
        [Header("Health")]
        [SerializeField] private int _maxHealth = 1;
        private int _currentHealth = 0;


        #region MONO

        private void Start()
        {
            _currentHealth = _maxHealth;
        }

        #endregion

        #region Private Methods

        private void CheckHealth()
        {
            if (_currentHealth <= 0) DestroyEnemy();
        }

        private void DestroyEnemy()
        {
            Debug.Log("Destroy");

            //effect

            Destroy(gameObject);
        }

        #endregion

        #region Public Methods

        public void OnTakeDamage(int damageValue)
        {
            _currentHealth -= damageValue;

            CheckHealth();
        }

        #endregion
    }
}