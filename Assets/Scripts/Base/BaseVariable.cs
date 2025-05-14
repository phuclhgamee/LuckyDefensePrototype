﻿using System;
using UnityEngine;

namespace LuckyDenfensePrototype
{
    public class BaseVariable<TType> : BaseEvent<TType>, ISerializationCallbackReceiver
    {
        [SerializeField] TType initializeValue;
        [SerializeField] bool isSavable;
        [SerializeField] bool isRaiseEvent;
        [NonSerialized] TType runtimeValue;

        public TType Value
        {
            get => runtimeValue;
            set
            {
                runtimeValue = value;
                if (isRaiseEvent)
                {
                    Raise(value);
                }
            }
        }

        public void OnBeforeSerialize()
        {
        }

        public void OnAfterDeserialize()
        {
            runtimeValue = initializeValue;
        }

        public void Reset()
        {
            Value = initializeValue;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}