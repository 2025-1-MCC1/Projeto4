﻿using System;
using UnityEngine;

public class Readme2 : ScriptableObject
{
    public Texture2D icon;
    public string title;
    public Section[] sections;
    public bool loadedLayout;

    [System.Serializable]
    public class Section
    {
        public string heading, text, linkText, url;
    }
}

