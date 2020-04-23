namespace Echiquier
{
    public class Variables
    {
        public static byte g_byteNbrCases = 8;
        public static int[] g_intTabPosBufferXY = { -1, -1 };
        public static bool[,] g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];
        public static bool[] g_boolTabCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
    }
}
