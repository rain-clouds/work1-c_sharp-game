using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stat : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private Text statValue;

    private float lerpSpeed = 1.2f;

    private float currentFill;

    public float MyMaxValue { get; set; }

    private float currentValue;

    public float MyCurrentValue
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue)
            {
                currentValue = MyMaxValue;
            }
            else if(value <0)
            {
                currentValue = 0;
            }
            else { currentValue = value; }

            currentFill = currentValue / MyMaxValue;

            if(statValue!=null)
            {
                statValue.text = currentValue + " / " + MyMaxValue;
            }
            
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
        content = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(content.fillAmount != currentFill)
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }

        
    }

    public void Initialize(float currentValue, float MaxValue)
    {
        if(content==null)
        {
            content = GetComponent<Image>();
        }

        MyMaxValue = MaxValue;
        MyCurrentValue = currentValue;
        content.fillAmount = MyCurrentValue / MyMaxValue;
    }
}
