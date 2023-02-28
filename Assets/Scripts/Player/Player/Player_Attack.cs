using UnityEngine;

namespace Players
{
    [RequireComponent(typeof(Animator))]
    public class Player_Attack : MonoBehaviour
    {
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
                OnAttack(collision, _damageValue);
            }
        }

        #endregion

        #region Private Methods

        private void OnAttack(Collision collision, int damageValue)
        {
            //нанесение урона врагу
            //collision.TakeDamege(_damageValue);

            _animator.SetTrigger(NAME_ATTACK_ANIMATION);
        }

        #endregion
    }
}