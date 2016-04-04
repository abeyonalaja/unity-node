using UnityEngine;
using System.Collections;
using SocketIO;
using System;

public class Network : MonoBehaviour {

    static SocketIOComponent socket;
    public GameObject playerPrefab;
    
	// Use this for initialization
	void Start () {
        socket = GetComponent<SocketIOComponent>();
        socket.On("open", OnConnected);
        socket.On("spawn", OnSpawned);
	}

    private void OnSpawned(SocketIOEvent e)
    {
        Debug.Log("spawned");
        Instantiate(playerPrefab);
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
        socket.Emit("move");
    }




    // Update is called once per frame
    void Update () {
	
	}
}
