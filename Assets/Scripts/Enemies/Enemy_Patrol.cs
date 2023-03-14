using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using DG.Tweening;
using Character.Slingshot;

namespace Enemies
{
    public enum PatrolTypes
    {
        Non = 0,
        PointToPoint = 1,
        Trajectory = 2,
        Harassment = 3,
    }

    [RequireComponent (typeof(Transform))]
    public class Enemy_Patrol : MonoBehaviour
    {
        #region ACTION

        public static Action OnStartMovement = null;
        public static Action OnStopMovement = null;

        #endregion

        #region CONSTS

        private const float Y_POSITION = 1f;

        #endregion

        public bool IsPatrolActive = true;

        public PatrolTypes PatrolType = PatrolTypes.PointToPoint;

        public bool IsXPatrol = true;

        public float TimePatrol = 2f;
        public float[] PointToPointTransformPosition = null;

        private int _pointPatrolIndex = 0;

        private Transform _transform = null;


        #region MONO

        private void Awake()
        {
            _transform = GetComponent<Transform>();
        }

        private void OnEnable()
        {
            Player_Slingshot.OnSlinged += Patroling;
        }

        private void OnDisable()
        {
            Player_Slingshot.OnSlinged -= Patroling;
        }

        #endregion

        #region Private Methods

        private void Patroling()
        {
            if (IsPatrolActive == false)
            {
                StartCoroutine(SkipPatrolCoroutine());

                return;
            }

            if (PatrolType == PatrolTypes.PointToPoint) PointToPointPatrol();
        }

        private void PointToPointPatrol()
        {
            Vector3 newPosition = Vector3.zero;

            if (IsXPatrol == true) newPosition = new Vector3(PointToPointTransformPosition[_pointPatrolIndex], Y_POSITION, _transform.position.z);
            if (IsXPatrol == false) newPosition = new Vector3(_transform.position.x, Y_POSITION, PointToPointTransformPosition[_pointPatrolIndex]);

            StartCoroutine(PatrolingCoroutine(newPosition));
        }

        private void ChangePatrolIndex()
        {
            _pointPatrolIndex++;

            if (_pointPatrolIndex >= PointToPointTransformPosition.Length) _pointPatrolIndex = 0;
        }

        #region Coroutines

        private IEnumerator SkipPatrolCoroutine()
        {
            OnStopMovement?.Invoke();

            yield break;
        }

        private IEnumerator PatrolingCoroutine(Vector3 newPosition)
        {
            OnStartMovement?.Invoke();

            _transform.DOMove(newPosition, TimePatrol);

            yield return new WaitForSeconds(TimePatrol);

            ChangePatrolIndex();

            OnStopMovement?.Invoke();

            yield break;
        }

        #endregion

        #endregion
    }


    #region Editor

    [CustomEditor(typeof(Enemy_Patrol))]
    public class Enemy_PatrolEditor : Editor
    {
        #region SerializedProperty

        private SerializedProperty _isPatrolActive = null;

        private SerializedProperty _patrolType = null;

        private SerializedProperty _timePatrol = null;
        private SerializedProperty _isXPatrol = null;
        private SerializedProperty _pointToPointTransformPosition = null;

        #endregion

        #region Private Methods 

        private void OnEnable()
        {
            _isPatrolActive = serializedObject.FindProperty("IsPatrolActive");

            _patrolType = serializedObject.FindProperty("PatrolType");

            _timePatrol = serializedObject.FindProperty("TimePatrol");
            _isXPatrol = serializedObject.FindProperty("IsXPatrol");
            _pointToPointTransformPosition = serializedObject.FindProperty("PointToPointTransformPosition");
        }

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            Enemy_Patrol _cutSceneActions = (Enemy_Patrol)target;

            serializedObject.Update();

            EditorGUILayout.LabelField("Patrol");
            EditorGUILayout.PropertyField(_isPatrolActive);
            EditorGUILayout.Space(5f);

            if(_isPatrolActive.boolValue == true)
            {
                EditorGUILayout.LabelField("Patrol Parameters");
                EditorGUILayout.PropertyField(_patrolType);
                EditorGUILayout.PropertyField(_timePatrol);
                EditorGUILayout.Space(5f);

                if (_cutSceneActions.PatrolType == PatrolTypes.PointToPoint)
                {
                    EditorGUILayout.PropertyField(_isXPatrol);
                    EditorGUILayout.PropertyField(_pointToPointTransformPosition);
                }
            }

            serializedObject.ApplyModifiedProperties();
        }

        #endregion

    }
    
    #endregion
}