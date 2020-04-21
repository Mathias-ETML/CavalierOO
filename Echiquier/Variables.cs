namespace Echiquier
{
    public class Variables
    {
        public static byte g_byteNbrCases = 8;
        public static byte g_bytePosCavalierCaseX = (byte)(g_byteNbrCases - 3 - 1);
        public static int[] g_intPosBufferXY = { 0, 0 };
        public static bool[,] g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];
        public static bool[] g_boolCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
    }
}
