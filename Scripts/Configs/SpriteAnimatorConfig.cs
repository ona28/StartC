using System;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer2D
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2,
        Forward = 3,
        Left = 4,
        Right = 5,
        Back = 6
    }

    [CreateAssetMenu(fileName = "SpriteAnimationCfg", menuName = "Configs/ Animation", order = 1)]
    public class SpriteAnimatorConfig : ScriptableObject
    {
        [Serializable]
        public sealed class SpriteSequence
        {
            public string NameAnimation;
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSequence> Sequence = new List<SpriteSequence>();
    }
}
