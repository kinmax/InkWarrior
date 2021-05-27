using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InkBarController : MonoBehaviour
{
    public Slider slider;
    [SerializeField] InkLevelController inkLevelController;

    // Start is called before the first frame update
    void Start()
    {
        SetInk(inkLevelController.getInkLevel());
    }

    // Update is called once per frame
    void Update()
    {
        SetInk(inkLevelController.getInkLevel());
    }

    public void SetInk(int ink)
    {
        slider.value = ink;
    }
}
