using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Camera : MonoBehaviour {

	public GameObject player;
    public float distance;
    private Vector3 offset;
    public Slider slider;
    
	void Start () {
		offset = transform.position - player.transform.position;
	}
	void LateUpdate () {
		transform.position = player.transform.position + offset + new Vector3(distance, distance, distance);
	}

    public void cambiarDistancia() {
        if (slider != null) {
            distance = slider.value;
        } 
    }
}
