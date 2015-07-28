using System.Collections.Generic;
using System.Collections;
using System;
using UnityEngine;
using SocketIO;
using UnityEngine.UI;

public class TestSocketIO : MonoBehaviour
{
	public GameObject guiText;
	private SocketIOComponent socket;
	private Color _bgColor = Color.black;
	private Text _guiText;
	private Color _guiColor = Color.white;

	public void Start() 
	{
		GameObject go = GameObject.Find("SocketIO");
		socket = go.GetComponent<SocketIOComponent>();
		socket.On ("rgb",changeBackgroundRGB);

		_guiText = guiText.GetComponent<Text> ();
	}

	public void Update(){
		if (Input.GetMouseButtonDown (0)) {


			Color rndColor = new Color(UnityEngine.Random.value,UnityEngine.Random.value,UnityEngine.Random.value);

			Dictionary<string,string> json = new Dictionary<string, string>();
			json.Add("r",((int)(rndColor.r * 255)).ToString());
			json.Add("g",((int)(rndColor.g * 255)).ToString());
			json.Add("b",((int)(rndColor.b * 255)).ToString());

			socket.Emit("rgb",new JSONObject(json));
			_bgColor = rndColor;
		}

		Camera.main.backgroundColor = _bgColor;
		_guiText.color = _guiColor;
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
		_guiColor = InvertedColor (_bgColor);
		Debug.Log (_guiColor);
	}

	private Color InvertedColor (Color inputC){
		return new Color(1f - inputC.r,
		                 1f - inputC.g,
		                 1f - inputC.b,
		                 1f);
	}
}
