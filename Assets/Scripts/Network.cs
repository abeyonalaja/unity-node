using UnityEngine;
using System.Collections.Generic;
using SocketIO;
using System;

public class Network : MonoBehaviour {

    static SocketIOComponent socket;
    public GameObject playerPrefab;
    
    Dictionary<string, GameObject>players;
	// Use this for initialization
	void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
        socket.On("move", OnMove);
        
        players = new Dictionary<string, GameObject>();
	}

    private void OnMove(SocketIOEvent e)
    {
        Debug.Log("A Player is moving " + e.data    );
    }

    private void OnSpawned(SocketIOEvent e)
    {
        // Debug.Log("spawned player " + e.data);
        var player = Instantiate(playerPrefab);
        
        players.Add(e.data["id"].ToString(), player);
        
        Debug.Log("count: " + players.Count);
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
    }




    // Update is called once per frame
    void Update () {
	
	}
}
