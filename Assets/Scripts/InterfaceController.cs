using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InterfaceController : MonoBehaviour
{
    private PlayerController scriptPlayerController;
    private PentaScript scriptPentaScript;
    public Slider SliderPlayerLife;
    public Slider SliderPlayerCollections;


    void Start()
    {
        scriptPlayerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        scriptPentaScript = GameObject.FindWithTag("Penta").GetComponent<PentaScript>();
        SliderPlayerLife.maxValue = scriptPlayerController.Life;
        SliderPlayerCollections.maxValue = scriptPentaScript.TotalCollections;
        UpdateSlidePlayerLife();
        UpdateSlidePlayerCollections();
    }

    public void UpdateSlidePlayerLife ()
    {
        SliderPlayerLife.value = scriptPlayerController.Life;
    }
    public void UpdateSlidePlayerCollections ()
    {
        SliderPlayerCollections.value = scriptPlayerController.Collections;
    }
}
