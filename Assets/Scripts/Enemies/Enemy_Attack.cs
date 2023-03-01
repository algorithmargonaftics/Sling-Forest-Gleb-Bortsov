using UnityEngine;

namespace Enemies
{
    public class Enemy_Attack : MonoBehaviour
    {
        #region CONSTS

        private const float Y_POSITION = 1f;

        #endregion

        [Header("Health")]
        [SerializeField] private int _maxHealth = 1;
        private int _currentHealth = 0;
        [Space (height: 5f)]

        [SerializeField] private ParticleSystem _destroyEffect = null;


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
            Instantiate(
                _destroyEffect,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Y_POSITION, gameObject.transform.position.z),
                Quaternion.identity);

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