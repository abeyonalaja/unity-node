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
        socket.On("registered", OnRegistered);
        socket.On("disconnected", OnDisconnected);
        
        players = new Dictionary<string, GameObject>();
	}

    private void OnDisconnected(SocketIOEvent e)
    {
        Debug.Log("Player disconnected: " + e.data);
        var id = e.data["id"].ToString();
        var player = players[id];
        Destroy(player);
        players.Remove(id);
    }

    private void OnMove(SocketIOEvent e)
    {
        Debug.Log("A Player is moving " + e.data    );
        var x = GetFloatFromJson( e.data, "x");
        var z = GetFloatFromJson( e.data, "y");
        var pos = new Vector3(x, 0, z);
        var id = e.data["id"].ToString();
        var player = players [id];
       
        var navigatePos = player.GetComponent<NavigateToPosition>();
        navigatePos.NavigateTo(pos);
        
        Debug.Log(player.name);
    }

    private void OnSpawned(SocketIOEvent e)
    {
        // Debug.Log("spawned player " + e.data);
        var player = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        
        var x = GetFloatFromJson( e.data, "x");
        var z = GetFloatFromJson( e.data, "y");
        var movePositon = new Vector3(x, 0, z);
        
        var navigatePos = player.GetComponent<NavigateToPosition>();
        navigatePos.NavigateTo(movePositon);
        
        players.Add(e.data["id"].ToString(), player);
        
        Debug.Log("count: " + players.Count);
    }

    private void OnConnected(SocketIOEvent e)
    {
        Debug.Log("connected");
    }
    
    private void OnRegistered(SocketIOEvent e)
    {
        Debug.Log("registered" + e.data);
    }
    
    float GetFloatFromJson(JSONObject data, string key) {
        return float.Parse(data[key].ToString().Replace("\"", ""));
    }




    // Update is called once per frame
    void Update () {
	
	}
}
