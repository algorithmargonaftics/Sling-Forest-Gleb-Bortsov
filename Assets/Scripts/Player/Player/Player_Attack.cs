using UnityEngine;
using System;
using Enemies;

namespace Character
{
    [RequireComponent(typeof(Animator))]
    public class Player_Attack : MonoBehaviour
    {
        #region ACTION

        public static Action OnTakeDamage = null;

        #endregion

        #region CONSTS

        private const string TAG_ENEMY = "Enemy";
        private const string NAME_ATTACK_ANIMATION = "OnAttack";

        #endregion

        [Header("Parameters")]
        [SerializeField] private int _damageValue = 2;

        private Animator _animator = null;


        #region MONO

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag(TAG_ENEMY))
            {
                Enemy_Attack enemy = collision.gameObject.GetComponent<Enemy_Attack>();

                OnAttack(enemy, _damageValue);
            }
        }

        #endregion

        #region Private Methods

        private void OnAttack(Enemy_Attack enemy, int damageValue)
        {
            enemy.OnTakeDamage(damageValue);

            _animator.SetTrigger(NAME_ATTACK_ANIMATION);

            OnTakeDamage?.Invoke();
        }

        #endregion
    }
}