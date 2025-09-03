namespace MiningFarm.Utilities.Extensions
{
    public static class StringColorExtension
    {
        public static string ToWhite(this string str) => $"<color=white>{str}</color>";
        public static string ToYellow(this string str) => $"<color=#e49600>{str}</color>";
        public static string ToLightRed(this string str) => $"<color=#FF7766>{str}</color>";
        public static string ToGreen(this string str) => $"<color=#0AA22E>{str}</color>";
        public static string ToCyan(this string str) => $"<color=cyan>{str}</color>";
        public static string ToRed(this string str) => $"<color=red>{str}</color>";
        public static string ToBlue(this string str) => $"<color=blue>{str}</color>";
        public static string ToOrange(this string str) => $"<color=orange>{str}</color>";
    }
}