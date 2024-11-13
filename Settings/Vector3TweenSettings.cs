namespace Game.Runtime.EasyPrimeTweens.Settings
{
    using System;
    using Data;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class Vector3TweenSettings
    {
        [SerializeField]
        private PlayInSequenceType playInSequenceType;
        
        [SerializeField]
        private bool localOrientation;
        [SerializeField]
        private bool from;
        
        [SerializeField, ReadOnly]
        private Vector3 fromValue;

        public Vector3 FromValue => fromValue;
        public bool LocalOrientation => localOrientation;
        public bool From => from;

        private bool _fromValueIsSet;

        public void SetFromValue(Vector3 position)
        { 
            if (_fromValueIsSet) return;
            
            fromValue = position;
            _fromValueIsSet = true;
        }

        public PlayInSequenceType GetPlayInSequenceType()
        {
            return playInSequenceType;
        }
    }
}