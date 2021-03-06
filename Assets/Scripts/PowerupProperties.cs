﻿using UnityEngine;

public static class PowerupProperties
{
    static PowerupProperties() // Init variables here
    {
        coinMultiplicatorPower = 2;
        coinMultiplicatorDuration = 4f;
        magnetDuration = 4f;
        invincibleDuration = 4f;
    }

    public static int coinMultiplicatorPower; // Multiplicator of the coin multiplicator powerup
    public static float coinMultiplicatorDuration; // Duration in seconds

    public static float magnetDuration; // Duration in seconds

    public static float invincibleDuration; // Duration in seconds
}
