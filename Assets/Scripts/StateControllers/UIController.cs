﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public void PlayButtonPressSound()
    {
        AudioController.Instance.PlaySparkle();
    }
}
