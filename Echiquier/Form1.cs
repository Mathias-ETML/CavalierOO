using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Echiquier.Variables;

namespace Echiquier
{
    public partial class FrmMaSuperForme : Form
    {
        // variables globales
        private List<PictureBox> g_ListePicBox = new List<PictureBox>();
        private Image g_imageCavalier = new Bitmap(Properties.Resources.cav64);

        public FrmMaSuperForme()
        {
            InitializeComponent();
        }

        private void Echiquer()
        {
            // (re)inti variables + (re)init tableaux
            short shortBuffer = 0;
            g_boolTabCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
            g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];

            for (int y = 0; y < g_byteNbrCases; y++)
            {
                for (int x = 0; x < g_byteNbrCases; x++)
                {
                    // initialise le tablea du joueur avec des false, donc il n'est pas passé par la
                    g_boolTabJoueur[x, y] = false;

                    // initalise le tableau qui va être flattent de true
                    g_boolTabCheckCavalierFini[shortBuffer + x] = true;

                    // crée la picture box
                    PictureBox picBox = new PictureBox();

                    // définie la taille de la picture box
                    picBox.Size = new Size(panEchiquier.Width / g_byteNbrCases, panEchiquier.Height / g_byteNbrCases);

                    // défini le nom
                    // prends la position de X, puis ajoute 65 pour avoir le caratère ASCII
                    picBox.Name = (char)(x + 65) + " " + y.ToString();

                    // défini la bordure
                    picBox.BorderStyle = BorderStyle.FixedSingle;

                    // définie la position de la picture box
                    picBox.Location = new Point(x * picBox.Width, y * picBox.Height);

                    // check si il faut mettre du blanc ou du orange
                    picBox.BackColor = (x + y) % 2 == 0 ? Color.White : Color.Orange;

                    // premier event handler qui va tout initaliser
                    picBox.Click += new EventHandler(PosCavalierViaClick);

                    picBox.MouseEnter += new EventHandler(ChoixCaseAvecCavalier);

                    picBox.MouseLeave += new EventHandler(Removeg_imageCavalierChoixCase);

                    // met l'image par raport a la taille de la picture box
                    picBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    // ajoute au panel les picture box
                    panEchiquier.Controls.Add(picBox);

                    // ajoute la picture box au bouton
                    g_ListePicBox.Add(picBox);
                }

                // permet de buffer la position dans le tableau
                shortBuffer += g_byteNbrCases;
            }

            // set la dernière case du tableau en true
            g_boolTabCheckCavalierFini[shortBuffer - 1] = true;
        }

        private void InfoCase(object sender, EventArgs e)
        {
            // défini  le nom du label
            labInfoCases.Text = "Case : " + ((Control)sender).Name.ToString();
        }

        private void PositionCavalier(object sender, EventArgs e)
        {
            // variables
            bool[] tab_boolTabJoueurFlatten;

            // split le nom du picBox dans un tbl de string
            PictureBox CtrlSender = (PictureBox)sender;
            string[] tab_strStringNamePicBox = CtrlSender.Name.Split(' ');

            // permet de changer le nom du picBox en position XY dans le cavalier
            byte[] tab_bytePosXYViaNom = new byte[] { (byte)((byte)Convert.ToChar(tab_strStringNamePicBox[0]) - 65), Convert.ToByte(tab_strStringNamePicBox[1]) };

            // check si le joueur a cliqué sur une position valide
            if (CheckPos(CtrlSender.Location.X, CtrlSender.Location.Y, CtrlSender.Width))
            {
                // set dans la position XY du joueur que il est allé sur cette case
                g_boolTabJoueur[tab_bytePosXYViaNom[0], tab_bytePosXYViaNom[1]] = true;

                // met le cavalier sur la case ou le joueur a cliqué
                CtrlSender.Image = g_imageCavalier;

                // check si le cavalier est déjà passé par la case
                if (CtrlSender.BackColor != Color.Green && CtrlSender.BackColor != Color.DarkGreen)
                {
                    // check quel ton de vert il doit mettre par rapport a la case
                    CtrlSender.BackColor = (tab_bytePosXYViaNom[0] + tab_bytePosXYViaNom[1]) % 2 == 0 ? Color.Green : Color.DarkGreen;
                }
                // si non alors remet la couleur de base
                else
                {
                    // reset le true de la position XY du joueur vu que il est déjà passé par la
                    g_boolTabJoueur[tab_bytePosXYViaNom[0], tab_bytePosXYViaNom[1]] = false;

                    // check quel devrait être la couleur a remettre
                    CtrlSender.BackColor = (tab_bytePosXYViaNom[0] + tab_bytePosXYViaNom[1]) % 2 == 0 ? Color.White : Color.Orange;
                }

                // flatten le tableau du joueur pour que il puisse être comparé
                tab_boolTabJoueurFlatten = g_boolTabJoueur.Cast<bool>().ToArray();

                // check si le joueur a fini le cavalier en comparant les tableaux flattent
                if (tab_boolTabJoueurFlatten.SequenceEqual(g_boolTabCheckCavalierFini))
                {
                    MessageBox.Show("Bravo, vous avez gagné");

                    Dispose();
                }
            }
            // si non alors joueur a cliquer sur mauvaise case
            else
            {
                MessageBox.Show("Le cavalier ne peut pas se déplacer sur cette case");
            }
        }

        private bool CheckPos(int intX, int intY, int intWidth)
        {
            // variables
            int TailleCase = panEchiquier.Width / g_byteNbrCases;
            int[] tabPosXY = new int[] { intX, intY };

            // ici le but est de voir par rapport a la case cliqué si le cavalier se trouve dessus
            // les commentaires montre ou le joueur doit cliquer pour que la condition soit true
            // la condition check par rapport a la case cliqué
            // mon point d'origine est en haut a gauche, donc le 0,0
            // check a chaque fois si le cavalier est dans une position légal
            if (intX - TailleCase * 1 == g_intTabPosBufferXY[0] && intY + TailleCase * 2 == g_intTabPosBufferXY[1]) //  + 1x // + 2y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX - TailleCase * 2 == g_intTabPosBufferXY[0] && intY + TailleCase * 1 == g_intTabPosBufferXY[1]) //  + 2x // + 1y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX - TailleCase * 2 == g_intTabPosBufferXY[0] && intY - TailleCase * 1 == g_intTabPosBufferXY[1]) // + 2x // - 1y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX - TailleCase * 1 == g_intTabPosBufferXY[0] && intY - TailleCase * 2 == g_intTabPosBufferXY[1]) // + 1x // - 2y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            // fin droite
            else if (intX + TailleCase * 1 == g_intTabPosBufferXY[0] && intY - TailleCase * 2 == g_intTabPosBufferXY[1]) // - 1x // - 2y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX + TailleCase * 2 == g_intTabPosBufferXY[0] && intY - TailleCase * 1 == g_intTabPosBufferXY[1]) // - 2x // - 1y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX + TailleCase * 2 == g_intTabPosBufferXY[0] && intY + TailleCase * 1 == g_intTabPosBufferXY[1]) // -2x + 1y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            else if (intX + TailleCase * 1 == g_intTabPosBufferXY[0] && intY + TailleCase * 2 == g_intTabPosBufferXY[1]) // - 1x + 2y
            {
                return ChangementBuffer(intX, intY, intWidth);
            }
            // si non alors joueur clique sur mauvaise case
            else
            {
                return false;
            }
        }

        private bool ChangementBuffer(int intX, int intY, int intWidth)
        {
            // permet d'enlever l'image du cavalier de la case précèdente
            g_ListePicBox[((((g_intTabPosBufferXY[1] / intWidth) + 1) * g_byteNbrCases) - (g_byteNbrCases - ((g_intTabPosBufferXY[0] / intWidth) + 1))) - 1].Image = null;

            // permet de compacter les lignes de codes qui revenait dans la méthode CheckPos
            g_intTabPosBufferXY[0] = intX;
            g_intTabPosBufferXY[1] = intY;

            // return forcément true que que la methode a été appelé
            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // fait disparaitre le cavalier en le disposant grace a foreach
            foreach (PictureBox item in g_ListePicBox)
            {
                item.Dispose();
            }

            // reset des variables
            g_intTabPosBufferXY = new int[g_byteNbrCases * g_byteNbrCases];
            g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];
            g_boolTabCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
            g_ListePicBox.Clear();

            // recall les fonctions, donc permet de refaire aparaitre le cavalier et l'echiquier
            Echiquer();

            // montre a l'user ce que il doit faire
            MessageBox.Show("Appuyez sur une case pour poser votre cavalier !");
        }

        private void Initialisation()
        {           
            // active la visibilité des informations du cavalier
            labInfoCases.Visible = true;
            btnReset.Visible = true;
            panInfo.Visible = true;

            // desactive la visibilité de demande input nbr cases
            labNbrCases.Visible = false;
            txtBoxInputNbrCases.Visible = false;
            btnValiderNbrCases.Visible = false;

            // initialise l'echiquier
            Echiquer();

            // montre a l'user ce que il doit faire
            MessageBox.Show("Appuyez sur une case pour poser votre cavalier !");
        }

        private void btnValiderNbrCases_Click(object sender, EventArgs e)
        {
            // converti le nombre input dans la variable des nbr cases
            g_byteNbrCases = Convert.ToByte(txtBoxInputNbrCases.Text);

            // check si nombre entré est entre 4 et 16
            if (g_byteNbrCases >= 4 && g_byteNbrCases <= 16)
            {
                // initalisation echiquier
                Initialisation();
            }
            // si non montre message d'erreur
            else
            {
                MessageBox.Show("Entrez un nombre comprit entre 4 et 16");
            }
        }

        private void PosCavalierViaClick(object sender, EventArgs e)
        {
            // définition
            PictureBox CtrlSender = ((PictureBox)sender);

            // set dans le buffer la position du click
            g_intTabPosBufferXY[0] = CtrlSender.Location.X;
            g_intTabPosBufferXY[1] = CtrlSender.Location.Y;

            // ckeck quel variation de couleur il doit mettre par rapport a la case ou le joueur a cliqué
            CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.Green : Color.DarkGreen;

            // set la location actuelle dans le tableau du joueur en trueM
            g_boolTabJoueur[CtrlSender.Location.X / CtrlSender.Width, CtrlSender.Location.Y / CtrlSender.Width] = true;

            // set l'echiquier sur la case cliqué
            CtrlSender.Image = g_imageCavalier;

            // permet d'ajouter les event handler check pose et de retirer celui utilisé actuellement
            foreach (PictureBox item in g_ListePicBox)
            {
                item.Click += new EventHandler(InfoCase);
                item.Click += new EventHandler(PositionCavalier);
                item.Click -= PosCavalierViaClick;
            }
        }

        private void ChoixCaseAvecCavalier(object sender, EventArgs e)
        {
            // set l'image du cavalier sur la case que l'user pointe
            ((PictureBox)sender).Image = g_imageCavalier;
        }

        private void Removeg_imageCavalierChoixCase(object sender, EventArgs e)
        {
            // check si la case ou la souris se trouve n'est pas la case ou le cavalier se trouve
            if (((PictureBox)sender).Location.X != g_intTabPosBufferXY[0] || ((PictureBox)sender).Location.Y != g_intTabPosBufferXY[1])
            {
                // enlève l'image dès que l'user n'a plus la souris sur la case
                ((PictureBox)sender).Image = null;
            }
        }
    }
}
