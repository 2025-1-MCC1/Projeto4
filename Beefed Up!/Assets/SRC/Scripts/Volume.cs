using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    [SerializeField] Slider volumeSlider;

    private void Awake() 
    
    {
        if (PlayerPrefs.HasKey("Volume"))
        {
            SetVolume(PlayerPrefs.GetFloat("Volume"));
            volumeSlider.value = PlayerPrefs.GetFloat("Volume");
        }
    }

    public void SetVolume(float Volume)
    {
        
        
        AudioListener.volume = Volume;
        PlayerPrefs.SetFloat("volume", Volume);
    
    }
}
