using UnityEngine;
using System;

namespace Locations.Objects
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Crystal : MonoBehaviour
    {
        #region ACTIONS

        public static Action<int> OnTake = null;

        #endregion

        #region CONSTS

        private const float Y_POSITION = 1f;

        private const string TAG_PLAYER = "Player";

        #endregion

        [Header("Parameters")]
        [SerializeField] private int _crystalValue = 0;
        [Space(height: 5f)]

        [SerializeField] private ParticleSystem _destroyEffect = null;


        #region MONO

        private void OnTriggerEnter(Collider collider)
        {
            if (collider.gameObject.CompareTag(TAG_PLAYER)) DestroyObject();
        }

        #endregion

        #region Private Methods

        private void DestroyObject()
        {
            OnTake?.Invoke(_crystalValue);

            Instantiate(
                _destroyEffect,
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Y_POSITION, gameObject.transform.position.z),
                Quaternion.identity);

            Destroy(gameObject);
        }

        #endregion
    }
}