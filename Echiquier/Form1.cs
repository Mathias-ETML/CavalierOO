using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Echiquier.Variables;


namespace Echiquier
{
    public partial class FrmMaSuperForme : Form
    {
        public FrmMaSuperForme()
        {
            InitializeComponent();

            DefPicBoxCavalier();

            Echiquer();
        }

        private void Echiquer()
        {
            g_intPosBufferXY = new int[2] { panEchiquier.Width / g_constbyteNbrCases * g_PosCavalierCaseX, 0 };

            bool[,] tab_boolFini2D = new bool[g_constbyteNbrCases, g_constbyteNbrCases];

            for (int y = 0; y < g_constbyteNbrCases; y++)
            {
                for (int x = 0; x < g_constbyteNbrCases; x++)
                {
                    // initialise le tablea du joueur avec des false, donc il n'est pas passé par la
                    g_boolTabJoueur[x, y] = false;

                    // initalise le tableau qui va être flattent de true
                    tab_boolFini2D[x, y] = true;

                    // crée la picture box
                    PictureBox picBox = new PictureBox();

                    // définie la taille de la picture box
                    picBox.Size = new Size(panEchiquier.Width / g_constbyteNbrCases, panEchiquier.Height / g_constbyteNbrCases);

                    // défini le nom
                    // prends la position de X, puis ajoute 65 pour avoir le caratère ASCII
                    picBox.Name = (char)(x + 65) + " " + y.ToString();

                    // défini la bordure
                    picBox.BorderStyle = BorderStyle.FixedSingle;

                    // définie la position de la picture box
                    picBox.Location = new Point(x * picBox.Width, y * picBox.Height);

                    // défini la couleur de la boite
                    if (x != g_PosCavalierCaseX || y != 0)
                    {
                        picBox.BackColor = (x + y) % 2 == 0 ? Color.White : Color.Orange;
                    }
                    else
                    {
                        picBox.BackColor = Color.Green;
                    }

                    // défini ce qui se passe quand on click dessus
                    picBox.Click += new EventHandler(InfoCase);

                    // defini ce qui se passe quand on click dessus
                    picBox.Click += new EventHandler(PositionCavalier);

                    // ajoute au panel les picture box
                    panEchiquier.Controls.Add(picBox);
                }
            }

            // flattent le tableau 2d en 1d
            g_boolCheckCavalierFini = tab_boolFini2D.Cast<bool>().ToArray();
        }

        private void InfoCase(object sender, EventArgs e)
        {
            // défini  le nom du label
            labInfoCases.Text = "Case : " + ((Control)sender).Name.ToString();
        }

        private void DefPicBoxCavalier()
        {
            // set la hauteur et largeur de la picture box
            picBoxCavalier.Size = new Size(panEchiquier.Width / g_constbyteNbrCases, panEchiquier.Height / g_constbyteNbrCases);

            // met l'image par raport a la taille de la picture box
            picBoxCavalier.SizeMode = PictureBoxSizeMode.StretchImage;

            // set l'image de la picture box
            picBoxCavalier.Image = new Bitmap(Properties.Resources.cavalier_transp);

            // set le fond de la couleur en transparant
            picBoxCavalier.BackColor = Color.Transparent;

            // défini la bordure
            picBoxCavalier.BorderStyle = BorderStyle.FixedSingle;

            // def de la position d'origine
            picBoxCavalier.Location = new Point(g_PosCavalierCaseX * panEchiquier.Width / g_constbyteNbrCases, 0);

            // ajoute la picture box au cavalier
            panEchiquier.Controls.Add(picBoxCavalier);
        }

        private void PositionCavalier(object sender, EventArgs e)
        {
            bool[] tab_boolTabJoueurFlatten = g_boolTabJoueur.Cast<bool>().ToArray();

            // split le nom du picBox dans un tbl de string
            string[] tab_strStringNamePicBox = ((Control)sender).Name.Split(' ');

            // permet de changer le nom du picBox en position XY dans le cavalier
            byte[] tab_bytePosXYViaNom = new byte[] { (byte)((byte)Convert.ToChar(tab_strStringNamePicBox[0]) - 65), Convert.ToByte(tab_strStringNamePicBox[1])};

            // check si le joueur a cliqué sur une position valide
            if (CheckPos(((Control)sender).Location.X, ((Control)sender).Location.Y))
            {
                // set dans la position XY du joueur que il est allé sur cette case
                g_boolTabJoueur[tab_bytePosXYViaNom[0], tab_bytePosXYViaNom[1]] = true;

                // set la location de la picture box
                picBoxCavalier.Location = ((Control)sender).Location;

                // check si le cavalier est déjà passé par la case
                if (((Control)sender).BackColor != Color.Green)
                {
                    ((Control)sender).BackColor = Color.Green;
                }
                // si non alors remet la couleur de base
                else
                {
                    // reset le true de la position XY du joueur vu que il est déjà passé par la
                    g_boolTabJoueur[tab_bytePosXYViaNom[0], tab_bytePosXYViaNom[1]] = false;

                    // check quel devrait être la couleur a remettre
                    ((Control)sender).BackColor = (tab_bytePosXYViaNom[0] + tab_bytePosXYViaNom[1]) % 2 == 0 ? Color.White : Color.Orange;
                }

                if (!tab_boolTabJoueurFlatten.SequenceEqual(g_boolCheckCavalierFini))
                {
                    MessageBox.Show("Bravo, vous avez gagné");

                    Dispose();
                }
            }
            else
            {
                MessageBox.Show("Le cavalier ne peut pas se déplacer sur cette case");
            }
        }

        private bool CheckPos(int intX, int intY)
        {
            int TailleCase = panEchiquier.Width / g_constbyteNbrCases;
            int[] tabPosXY = new int[] { intX, intY };

            // ici j'inverse le +/- pour check l'ancienne position du joueur
            // check a chaque fois si le cavalier est dans une position légal
            if (intX - TailleCase * 1 == g_intPosBufferXY[0] && intY + TailleCase * 2 == g_intPosBufferXY[1]) //  + 1x // + 2y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX - TailleCase * 2 == g_intPosBufferXY[0] && intY + TailleCase * 1 == g_intPosBufferXY[1]) //  + 2x // + 1y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX - TailleCase * 2 == g_intPosBufferXY[0] && intY - TailleCase * 1 == g_intPosBufferXY[1]) // + 2x // - 1y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX - TailleCase * 1 == g_intPosBufferXY[0] && intY - TailleCase * 2 == g_intPosBufferXY[1]) // + 1x // - 2y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            // fin droite
            else if (intX + TailleCase * 1 == g_intPosBufferXY[0] && intY - TailleCase * 2 == g_intPosBufferXY[1]) // - 1x // - 2y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX + TailleCase * 2 == g_intPosBufferXY[0] && intY - TailleCase * 1 == g_intPosBufferXY[1]) // - 2x // - 1y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX + TailleCase * 2 == g_intPosBufferXY[0] && intY + TailleCase * 1 == g_intPosBufferXY[1]) // -2x + 1y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            else if (intX + TailleCase * 1 == g_intPosBufferXY[0] && intY + TailleCase * 2 == g_intPosBufferXY[1]) // - 1x + 2y
            {
                g_intPosBufferXY[0] = intX;
                g_intPosBufferXY[1] = intY;

                return true;
            }
            // si non alors joueur clique sur mauvaise case
            else
            {
                return false;
            }
        }
    }
}
