﻿using UnityEngine;
using System.Collections;

public class NavigateToPosition : MonoBehaviour {

    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	
	}
	
	
	public void NavigateTo (Vector3 position) {
	    agent.SetDestination(position);
	}
}
