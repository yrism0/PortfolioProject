using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessing : MonoBehaviour
{
    [SerializeField] Volume postpVol;
    [SerializeField] private Vignette vign;
    [SerializeField] private ChromaticAberration chro;
    [SerializeField] private FilmGrain grain;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   

        postpVol = GetComponent<Volume>();
        postpVol.profile.TryGet(out vign);
        postpVol.profile.TryGet(out chro);
        postpVol.profile.TryGet(out grain);


        vign.active = false;
        chro.active = false;
        grain.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        AddPostProcessing();
    }

    private void AddPostProcessing()
    {
        if (PlayerHealth.instance.isPlayerDead)
        {
            vign.active = true;
            chro.active = true;
            grain.active = true;
        }
    }
}
