using UnityEngine;
using System.Collections;

public class ClickMove : MonoBehaviour {
    
    public GameObject player;

	// Use this for initialization
	void Start () {
        
	}
	
	public void OnClick (Vector3 position) {
	    var navPos = player.GetComponent<NavigateToPosition>();
        navPos.NavigateTo(position);
	}
}
