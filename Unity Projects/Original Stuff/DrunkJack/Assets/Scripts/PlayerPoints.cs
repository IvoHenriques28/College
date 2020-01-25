using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPoints : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        slider.value = 100;
    }
    private void Update()
    {
        slider.value -= 0.1f;
        if(slider.value > 60)
        {
            slider.fillRect.GetComponent<Image>().color = Color.green;
        }
        else if(slider.value > 30 && slider.value < 60)
        {
            slider.fillRect.GetComponent<Image>().color = Color.yellow;
        }
        else if(slider.value < 30)
        {
            slider.fillRect.GetComponent<Image>().color = Color.red;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "maca")
        {
            PointSystem.points = PointSystem.points + 1;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Box")
        {
            PointSystem.points = PointSystem.points + 5;
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "Beer")
        {
            slider.value = 100;
            Destroy(other.gameObject);
        }
    }

}
