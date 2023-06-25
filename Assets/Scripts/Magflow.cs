using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Link: Normal, conducts power
/// Provide: Yellow, power provider
/// Receive: Red, all edges must receive power
/// </summary>
public enum MagType
{
    RECEIVE,
    PROVIDE,
    LINK
}

public class Magflow : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] private int x;
    [SerializeField] private int y;

    [SerializeField] private MagType magType;
    [SerializeField] private List<GameObject> links;

    [Header("Display")]
    [SerializeField] private SpriteRenderer magsprite;

    public void Setup(int x, int y, MagType magType, Sprite magSprite)
    {
        this.x = x;
        this.y = y;
        this.magType = magType;
        magsprite.sprite = magSprite;
    }

    /// <summary>
    /// Rotates the magflow clockwise. After this happens, update the links
    /// </summary>
    public void Rotate()
    {

    }
}
