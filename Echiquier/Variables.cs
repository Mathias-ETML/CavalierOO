namespace Echiquier
{
    public class Variables
    {
        public static byte g_byteNbrCases = 8;
        public static short[] g_shortTabPosBufferXY = { -1, -1 };
        public static bool[,] g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];
        public static bool[] g_boolTabCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
    }
}
