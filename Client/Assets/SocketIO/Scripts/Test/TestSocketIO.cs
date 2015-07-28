using System.Collections.Generic;
using System;

using System.Collections;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class TestSocketIO : MonoBehaviour
{
	private SocketIOComponent socket;
	private Color _bgColor = Color.black;

	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
		socket.On ("rgb",changeBackgroundRGB);
	}

	public void Update(){
		if (Input.GetMouseButtonDown (0)) {
			_bgColor = Color.green;
		}

		Camera.main.backgroundColor = _bgColor;
	}
	
	public void changeBackgroundRGB(SocketIOEvent e)
	{
		Debug.Log("[SocketIO] changeBackgroundRGB received: " + e.name + " " + e.data);
		JSONObject jo = e.data as JSONObject;

		Color bgColor = new Color (
								Convert.ToSingle(jo["r"].str) / 255f,
								Convert.ToSingle(jo["g"].str) / 255f, 
								Convert.ToSingle(jo["b"].str) / 255f,
								1f);
		_bgColor = bgColor;
	}
}
