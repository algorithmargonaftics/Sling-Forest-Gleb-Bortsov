using UnityEngine;

namespace Enemies
{
    [RequireComponent(typeof (Enemy_Attack), typeof (Enemy_Patrol))]
    public class Enemy_Movement : MonoBehaviour
    {
        #region MONO

        private void OnEnable()
        {
            //прием хода -> передвижение -> разрешение ходить дальше
        }

        private void OnDisable()
        {
            //прием хода
        }

        #endregion
    }
}