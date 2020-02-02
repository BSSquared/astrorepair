using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
	public float timeStart;
	public Text textBox;

	// Use this for initialization
	void Start()
	{
		timeStart = PlayerPrefs.GetFloat("Timer");
		textBox.text = timeStart.ToString();
	}

	// Update is called once per frame
	void Update()
	{
		timeStart += Time.deltaTime;
		PlayerPrefs.SetFloat("Timer", timeStart);
		textBox.text = Mathf.Round(timeStart).ToString();
	}
}