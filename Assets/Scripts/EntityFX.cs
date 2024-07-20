using System.Collections;
using UnityEngine;

public class EntityFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMat;
    private Material originalMat;

    [Header("Ailment colors")] 
    [SerializeField] private Color[] igniteColor;
    [SerializeField] private Color[] chillColor;
    [SerializeField] private Color[] shockColor;
    
    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMat = sr.material;
    }
    public void MakeTransperent(bool _transprent)
    {
        if (_transprent)
            sr.color = Color.clear;
        else
            sr.color = Color.white;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMat;
        Color currentColor = sr.color;
        sr.color = Color.white;
        
        yield return new WaitForSeconds(flashDuration);

        sr.color = currentColor;
        sr.material = originalMat;
    }

    private void RedColorBlink()
    {
        if (sr.color != Color.white)
            sr.color = Color.white;
        else
            sr.color = Color.red;
    }

    private void CancelColorChange()
    {
        CancelInvoke();
        sr.color = Color.white;
    }
    
    public void IgniteFxFor(float _seconds)
    {
        InvokeRepeating("IgniteColorFx", 0 , .3f);
        Invoke("CancelColorChange", _seconds);
    }
    
    public void ChillFxFor(float _seconds)
    {
        InvokeRepeating("ChillColorFx", 0 , .3f);
        Invoke("CancelColorChange", _seconds);
    }
    
    public void ShockFxFor(float _seconds)
    {
        InvokeRepeating("ShockColorFx", 0 , .3f);
        Invoke("CancelColorChange", _seconds);
    }
    
    private void IgniteColorFx()
    {
        sr.color = sr.color != igniteColor[0] ? igniteColor[0] : igniteColor[1];
    }
    
    private void ChillColorFx()
    {
        sr.color = sr.color != chillColor[0] ? chillColor[0] : chillColor[1];
    }
    
    private void ShockColorFx()
    {
        sr.color = sr.color != shockColor[0] ? shockColor[0] : shockColor[1];
    }    
}