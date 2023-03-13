using UnityEngine;
using System;

namespace Character
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Player_Movement : MonoBehaviour
    {
        #region ACTION

        public static Action OnFinishLevel = null;

        #endregion

        #region CONSTS

        private const string TAG_FINISH = "Finish";

        #endregion


        #region MONO

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(TAG_FINISH)) OnFinishLevel?.Invoke();
        }

        #endregion
    }
}