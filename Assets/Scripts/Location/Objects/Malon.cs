using UnityEngine;

namespace Locations.Objects
{
    [RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
    public class Malon : MonoBehaviour
    {
        #region CONSTS

        private const float Y_POSITION = 1f;

        #endregion

        [SerializeField] private ParticleSystem _destroyEffect = null;


        #region MONO

        private void OnCollisionEnter(Collision collision)
        {
            DestroyObject();
        }

        #endregion

        #region Private Methods

        private void DestroyObject()
        {
            Instantiate(
                _destroyEffect, 
                new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Y_POSITION, gameObject.transform.position.z),
                Quaternion.identity);

            Destroy(gameObject);
        }

        #endregion
    }
}