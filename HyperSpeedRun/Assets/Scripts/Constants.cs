﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


    public enum GameState
    {
        Start,
        Playing,
        Dead
    }

    public static class Constants
    {
        public static readonly string PlayerTag = "Player";
        public static readonly string AnimationStarted = "started";
        public static readonly string AnimationJump = "jump";
        public static readonly string WidePathBorderTag = "WidePathBorder";

        public static readonly string StatusTapToStart = "Tap to start";
        public static readonly string StatusDeadTapToStart = "Dead. Tap to start";
    }

