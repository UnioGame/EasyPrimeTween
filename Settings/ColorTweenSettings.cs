namespace Game.Runtime.EasyPrimeTweens.Settings
{
    using System;
    using Data;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class ColorTweenSettings
    {
        [SerializeField]
        private PlayInSequenceType playInSequenceType;
        
        [SerializeField]
        private bool from;
        
        [SerializeField, ReadOnly]
        private Color fromValue;

        public Color FromValue => fromValue;
        public bool From => from;

        private bool _fromValueIsSet;

        public void SetFromValue(Color value)
        { 
            if (_fromValueIsSet) return;
            
            fromValue = value;
            _fromValueIsSet = true;
        }
        public PlayInSequenceType GetPlayInSequenceType()
        {
            return playInSequenceType;
        }
    }
}