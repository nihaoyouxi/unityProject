using System;

public class RandomTool
{

    static int randomValue;
    static int len = 12;

    public static void GetRandomByRNGCryptoServiceProvider()
    {
        Random random = new Random(GetRandomSeed());
        randomValue = random.Next(0, len);
    }

    private static int GetRandomSeed()
    {
        byte[] bytes = new byte[4];
        System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        rng.GetBytes(bytes);
        return BitConverter.ToInt32(bytes, 0);

    }

    public static int GetRandomValue() {
        GetRandomByRNGCryptoServiceProvider();
        return randomValue;
    }

}
