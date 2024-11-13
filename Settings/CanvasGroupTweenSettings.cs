namespace Game.Runtime.EasyPrimeTweens.Settings
{
    using System;
    using Data;
    using Sirenix.OdinInspector;
    using UnityEngine;

    [Serializable]
    public class CanvasGroupTweenSettings
    {
        [SerializeField]
        private CanvasGroupSettings startAnimation;
        [SerializeField]
        private CanvasGroupSettings endAnimation;
        
        [SerializeField]
        private PlayInSequenceType playInSequenceType;
        [SerializeField]
        private bool from;
        [SerializeField, ReadOnly]
        private float fromValue;
    
        public bool From => from;
        public float FromValue => fromValue;
        public CanvasGroupSettings StartAnimation => startAnimation;
        public CanvasGroupSettings EndAnimation => endAnimation;
    
        private bool _fromValueIsSet;
    
        public void SetFromValue(float value)
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
    
    [Serializable]
    public class CanvasGroupSettings
    {
        public bool interactable;
        public bool blocksRaycasts;
        public bool ignoreParentGroups;
    }
}