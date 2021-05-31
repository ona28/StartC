using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Boxes
{
    [CreateAssetMenu(fileName = "BoxSettings", menuName = "Data/BoxSettings")]
    public sealed class DataBox : ScriptableObject
    {
        [Serializable]
        private struct BoxInfo
        {
            public TypeBox Type;
            public ViewBox BoxPrefab;
        }

        [SerializeField] private List<BoxInfo> _boxInfos;

        public ViewBox GetBox(TypeBox type)
        {
            var boxInfo = _boxInfos.First(info => info.Type == type);
            return boxInfo.BoxPrefab;
        }
    }
}