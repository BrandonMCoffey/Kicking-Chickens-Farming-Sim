using UnityEngine;

namespace ScriptableObjects.Feed
{
   [CreateAssetMenu(fileName = "SO_FeedData", menuName = "FarmScriptableObjects/Feed", order = 1)]
    public class SO_FeedDataBase : ScriptableObject
    {
        public string feedName;
        [Tooltip("How much the feed costs in eggs")]
        public int feedPrice;
        [Tooltip("How strong the feed is")]
        public int feedStrength;
        [Tooltip("How long the feed will last")]
        public float feedDuration;
        [Tooltip("How much feed is dropped at a time")]
        public int feedAmount;
        [Tooltip("The material the feed will use")]
        public Material feedMaterial;
    }
}