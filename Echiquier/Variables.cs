namespace Echiquier
{
    public class Variables
    {
        public const byte g_constbyteNbrCases = 8;
        public const byte g_PosCavalierCaseX = 5 - 1;
        public static int[] g_intPosBufferXY = { 0, 0 };
        public static bool[,] g_boolTabJoueur = new bool[g_constbyteNbrCases, g_constbyteNbrCases];
        public static bool[] g_boolCheckCavalierFini = new bool[g_constbyteNbrCases * g_constbyteNbrCases];
    }
}
