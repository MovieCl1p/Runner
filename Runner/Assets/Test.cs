using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]
    private Transform _player;

    [SerializeField]
    private Transform _platform;

    public void Start ()
    {
		
	}
	
	public void Update ()
    {
        Renderer platformRenderer = _platform.GetComponent<Renderer>();

        Vector3 playerLocalPosition = _platform.InverseTransformPoint(_player.position);
        
        //Debug.Log(playerLocalPosition.x);
    }
}
