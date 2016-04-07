using UnityEngine;
using System.Collections;
using SocketIO;

public class NetworkMove : MonoBehaviour {

    public SocketIOComponent socket;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void OnMove(Vector3 position) {
        Debug.Log("Sending postion to node " + position);
        socket.Emit("move", new JSONObject(VectorToJson(position)));
    }
    
    string VectorToJson(Vector3 vector) {
        return string.Format (@"{{""x"":""{0}"", ""y"": ""{1}""}}", vector.x, vector.z);
    }
}
