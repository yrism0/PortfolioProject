using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject credits;
    [SerializeField] private Animator camAnim;
    [SerializeField] private GameObject slFX;
    public GameObject options;
    public GameObject controlstab;
    public GameObject audiotab;
    public GameObject backbutton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowCredits()
    {
        menu.SetActive(false);
        credits.SetActive(true);
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);
    }

    public void ShowMenu()
    {
        menu.SetActive(true);
        credits.SetActive(false);
    }

    public void GameStart()
    {
        slFX.SetActive(true);
        menu.SetActive(false);
        camAnim.SetTrigger("Start");
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);
    }

    public void ShowOptions()
    {
        options.SetActive(true);
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);
        // menu.SetActive(false);
    }

    public void ShowControls()
    {
        controlstab.SetActive(true);
        audiotab.SetActive(false);
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);
    }

    public void ShowAudio()
    {
        controlstab.SetActive(false);
        audiotab.SetActive(true);
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);

    }
    public void backtomenu()
    {
        options.SetActive(false);
        controlstab.SetActive(false);
        audiotab.SetActive(false);
        menu.SetActive(true);
        AudioControl.Instance.Play(AudioControl.SoundType.MenuButton);
    }
}
