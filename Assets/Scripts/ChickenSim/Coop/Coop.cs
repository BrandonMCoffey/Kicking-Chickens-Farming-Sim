using System.Collections;
using UnityEngine;

public class Coop : MonoBehaviour
{
	[SerializeField] private MeshRenderer _feedRenderer;

    public void SetFeed(SO_FeedDataBase feed)
    {
	    _feedRenderer.material = feed.FeedMaterial;
	    
	    // Todo: Store feed for chickens to eat and update visuals
	    
	    // Todo: Chickens actually come to coop to eat feed
	    GameManager.SendFeedToChickens(feed);
    }
}
