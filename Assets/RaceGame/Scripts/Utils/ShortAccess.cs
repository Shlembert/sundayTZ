public static class B
{
    public static float SpeedInHourMultiplier { get { return C.KPHMult; } }
}

public static class C
{
    public const float MPHMult = 2.23693629f;
    public const float KPHMult = 3.6f;
}
