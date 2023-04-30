using UnityEngine;

[CreateAssetMenu(fileName = "SO_FeedData", menuName = "FarmScriptableObjects/Feed", order = 1)]
public class SO_FeedDataBase : ScriptableObject
{
    [SerializeField] private string _feedName;
    [Tooltip("How much the feed costs in eggs")]
    [SerializeField] private int _feedCost;
    [Tooltip("The material the feed will use")]
    [SerializeField] private Material _feedMaterial;

    public string FeedName => _feedName;
    public int FeedCost => _feedCost;
    public Material FeedMaterial => _feedMaterial;
    
    [Header("Settings")]
    [Tooltip("How strong the feed is")]
    [SerializeField] private int _feedStrength;
    [Tooltip("How long the feed will last")]
    [SerializeField] private float _feedDuration;
    [Tooltip("How much feed is dropped at a time")]
    [SerializeField] private int _feedAmount;
    
    public int FeedStrength => _feedStrength;
    public float FeedDuration => _feedDuration;
    public int FeedAmount => _feedAmount;
}
