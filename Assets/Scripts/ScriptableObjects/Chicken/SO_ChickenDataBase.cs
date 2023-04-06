using UnityEngine;

namespace ScriptableObjects.Chicken
{
    [CreateAssetMenu(fileName = "SO_ChickenData", menuName = "FarmScriptableObjects/Chicken", order = 0)]
    public class SO_ChickenDataBase : ScriptableObject
    {
        public string chickenName;
        [Tooltip("The number of eggs per lay event")]
        public int eggsPerLay;
        [Tooltip("The number of ticks between lay events")]
        public float eggsLayPerTick; 
        [Tooltip("The material the chicken will use")]
        public Material chickenMaterial;
    }
}