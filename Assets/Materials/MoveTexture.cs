using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class MoveTexture : MonoBehaviour
{
    [SerializeField] private Vector2 _scrollSpeed;
    //[SerializeField] private Transform _follow;

    private Renderer _rend;

    void Start()
    {
        _rend = GetComponent<Renderer>();
    }

    void Update()
    {
        //_rend.material.mainTextureOffset = new Vector2(Time.time*_scrollSpeed[0],Time.time*_scrollSpeed[1]);
        //_rend.material.mainTextureOffset = new Vector2(_follow.position[0]*_scrollSpeed[0],_follow.position[1]*_scrollSpeed[1]);
        _rend.material.mainTextureOffset += _scrollSpeed * Time.deltaTime;
    }
}
