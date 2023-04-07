using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _SelectQuality : MonoBehaviour
{
    void Awake()
    {
        QualitySettings.GetQualityLevel();
        Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void VeryLowQuality(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(0);
        }
    }
    public void LowQuality(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(1);
        }
    }

    public void MediumQuality(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(2);
        }
    }

    public void HighQuality(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(3);
        }
    }

    public void UltraQuality(bool quality)
    {
        if (quality)
        {
            QualitySettings.SetQualityLevel(5);
        }
    }
}
