using System;

public class TEAHelper {

    public static Byte[] Encrypt(Byte[] Data, Byte[] Key) {
        if (Data.Length == 0) {
            return Data;
        }
        return ToByteArray(Encrypt(ToUInt32Array(Data, true), ToUInt32Array(Key, false)), false);
    }

    public static Byte[] Decrypt(Byte[] Data, Byte[] Key) {
        if (Data.Length == 0) {
            return Data;
        }
        return ToByteArray(Decrypt(ToUInt32Array(Data, false), ToUInt32Array(Key, false)), true);
    }

    public static UInt32[] Encrypt(UInt32[] v, UInt32[] k) {
        Int32 n = v.Length - 1;
        if (n < 1) {
            return v;
        }
        if (k.Length < 4) {
            UInt32[] Key = new UInt32[4];
            k.CopyTo(Key, 0);
            k = Key;
        }
        UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum = 0, e;
        Int32 p, q = 6 + 52 / (n + 1);
        while (q-- > 0) {
            sum = unchecked(sum + delta);
            e = sum >> 2 & 3;
            for (p = 0; p < n; p++) {
                y = v[p + 1];
                z = unchecked(v[p] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
            }
            y = v[0];
            z = unchecked(v[n] += (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
        }
        return v;
    }

    public static UInt32[] Decrypt(UInt32[] v, UInt32[] k) {
        Int32 n = v.Length - 1;
        if (n < 1) {
            return v;
        }
        if (k.Length < 4) {
            UInt32[] Key = new UInt32[4];
            k.CopyTo(Key, 0);
            k = Key;
        }
        UInt32 z = v[n], y = v[0], delta = 0x9E3779B9, sum, e;
        Int32 p, q = 6 + 52 / (n + 1);
        sum = unchecked((UInt32)(q * delta));
        while (sum != 0) {
            e = sum >> 2 & 3;
            for (p = n; p > 0; p--) {
                z = v[p - 1];
                y = unchecked(v[p] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
            }
            z = v[n];
            y = unchecked(v[0] -= (z >> 5 ^ y << 2) + (y >> 3 ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z));
            sum = unchecked(sum - delta);
        }
        return v;
    }

    private static UInt32[] ToUInt32Array(Byte[] Data, Boolean IncludeLength) {
        Int32 n = (((Data.Length & 3) == 0) ? (Data.Length >> 2) : ((Data.Length >> 2) + 1));
        UInt32[] Result;
        if (IncludeLength) {
            Result = new UInt32[n + 1];
            Result[n] = (UInt32)Data.Length;
        }
        else {
            Result = new UInt32[n];
        }
        n = Data.Length;
        for (Int32 i = 0; i < n; i++) {
            Result[i >> 2] |= (UInt32)Data[i] << ((i & 3) << 3);
        }
        return Result;
    }

    private static Byte[] ToByteArray(UInt32[] Data, Boolean IncludeLength) {
        Int32 n;
        if (IncludeLength) {
            n = (Int32)Data[Data.Length - 1];
        }
        else {
            n = Data.Length << 2;
        }
        Byte[] Result = new Byte[n];
        for (Int32 i = 0; i < n; i++) {
            Result[i] = (Byte)(Data[i >> 2] >> ((i & 3) << 3));
        }
        return Result;
    }


    //public static uint DELTA = 0x9e3779b9;
    //MX (((z>>5^y<<2) + (y>>3^z<<4)) ^ ((sum^y) + (key[(p&3)^e] ^ z)))  
    //public static void btea(uint[] v, uint n, uint[] key) {
    //    uint y, z, sum;
    //    uint p, rounds, e;
    //    if (n > 1)            /* Coding Part */
    //    {
    //        rounds = 6 + 52 / n;
    //        sum = 0;
    //        z = v[n - 1];
    //        do {
    //            sum += DELTA;
    //            e = (sum >> 2) & 3;
    //            for (p = 0; p < n - 1; p++) {
    //                y = v[p + 1];
    //                z = v[p] += MX;
    //            }
    //            y = v[0];
    //            z = v[n - 1] += MX;
    //        }
    //        while (--rounds);
    //    }
    //    else if (n < -1)      /* Decoding Part */
    //    {
    //        n = -n;
    //        rounds = 6 + 52 / n;
    //        sum = rounds * DELTA;
    //        y = v[0];
    //        do {
    //            e = (sum >> 2) & 3;
    //            for (p = n - 1; p > 0; p--) {
    //                z = v[p - 1];
    //                y = v[p] -= MX;
    //            }
    //            z = v[n - 1];
    //            y = v[0] -= MX;
    //            sum -= DELTA;
    //        }
    //        while (--rounds);
    //    }
    //}

}