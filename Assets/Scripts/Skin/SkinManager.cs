using System;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _skinsSprite;
    [SerializeField] private SpriteRenderer _planeSpriteRenderer;

    private void Start()
    {
        UpdateSkinOnPlane();
    }

    internal void UpdateSkinOnPlane()
    {
        _planeSpriteRenderer.sprite = _skinsSprite[PlayerPrefs.GetInt("checkMarkIndex")];
    }

}
