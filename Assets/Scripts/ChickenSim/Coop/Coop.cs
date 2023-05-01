using System.Collections;
using UnityEngine;

public class Coop : MonoBehaviour
{
	[SerializeField] private MeshRenderer _feedRenderer;

    public void SetFeed(SO_FeedDataBase feed)
    {
	    _feedRenderer.material = feed.FeedMaterial;
    }
}
