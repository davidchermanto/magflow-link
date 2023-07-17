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
    [SerializeField] private List<LinkDirection> links;

    [Header("Display")]
    [SerializeField] private SpriteRenderer magsprite;

    private bool spinning;

    public void Setup(int x, int y, MagType magType, Sprite magSprite)
    {
        this.x = x;
        this.y = y;
        this.magType = magType;
        magsprite.sprite = magSprite;
    }

    public void AddLink(LinkDirection link)
    {
        if (!links.Contains(link))
        {
            links.Add(link);
        }
    }

    /// <summary>
    /// Rotates the magflow clockwise 60 degs. After this happens, update the links
    /// </summary>
    public void Rotate()
    {
        if(magType == MagType.LINK && !spinning)
        {
            StartCoroutine(RotateRoutine());
        }
    }

    private IEnumerator RotateRoutine()
    {
        spinning = true;

        float targ = ((int)(transform.localEulerAngles.z / 60) * 60f + 60);
        float curr = transform.localEulerAngles.z;
        float duration = 0.15f;
        float currtime = 0;

        while (currtime < duration)
        {
            currtime += Time.deltaTime;
            float angle = Mathf.Lerp(curr, targ, currtime / duration);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            yield return new WaitForEndOfFrame();
        }

        transform.rotation = Quaternion.Euler(0, 0, targ);
        spinning = false;
    }
}
