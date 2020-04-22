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

        public FrmMaSuperForme()
        {
            InitializeComponent();
        }

        private void Echiquer()
        {
            // re initialise les variables
            g_boolTabCheckCavalierFini = new bool[g_byteNbrCases * g_byteNbrCases];
            byte byteBuffer = 0;

            for (int y = 0; y < g_byteNbrCases; y++)
            {
                for (int x = 0; x < g_byteNbrCases; x++)
                {
                    // initialise le tablea du joueur avec des false, donc il n'est pas passé par la
                    g_boolTabJoueur[x, y] = false;

                    // initalise le tableau qui va être flattent de true
                    g_boolTabCheckCavalierFini[byteBuffer + x] = true;

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

                    // ajoute au panel les picture box
                    panEchiquier.Controls.Add(picBox);

                    // ajoute la picture box au bouton
                    g_ListePicBox.Add(picBox);
                }

                // permet de buffer la position dans le tableau
                byteBuffer += g_byteNbrCases;
            }

            // set la dernière case du tableau en true
            g_boolTabCheckCavalierFini[byteBuffer - 1] = true;
        }

        private void InfoCase(object sender, EventArgs e)
        {
            // défini  le nom du label
            labInfoCases.Text = "Case : " + ((Control)sender).Name.ToString();
        }

        private void DefPicBoxCavalier()
        {
            // permet d'invoquer une nouvelle picture box
            picBoxCavalier = new PictureBox();

            // set la hauteur et largeur de la picture box
            picBoxCavalier.Size = new Size(panEchiquier.Width / g_byteNbrCases, panEchiquier.Height / g_byteNbrCases);

            // met l'image par raport a la taille de la picture box
            picBoxCavalier.SizeMode = PictureBoxSizeMode.StretchImage;

            // set l'image de la picture box
            picBoxCavalier.Image = new Bitmap(Properties.Resources.cavalier_transp);

            // set le fond de la couleur en transparant
            picBoxCavalier.BackColor = Color.Transparent;

            // défini la bordure
            picBoxCavalier.BorderStyle = BorderStyle.FixedSingle;
        }

        private void PositionCavalier(object sender, EventArgs e)
        {
            // flatten le tableau
            bool[] tab_boolTabJoueurFlatten; // = g_boolTabJoueur.Cast<bool>().ToArray();

            // split le nom du picBox dans un tbl de string
            Control CtrlSender = (Control)sender;
            string[] tab_strStringNamePicBox = CtrlSender.Name.Split(' ');

            // permet de changer le nom du picBox en position XY dans le cavalier
            byte[] tab_bytePosXYViaNom = new byte[] { (byte)((byte)Convert.ToChar(tab_strStringNamePicBox[0]) - 65), Convert.ToByte(tab_strStringNamePicBox[1]) };

            // check si le joueur a cliqué sur une position valide
            if (CheckPos(CtrlSender.Location.X, CtrlSender.Location.Y))
            {
                // set dans la position XY du joueur que il est allé sur cette case
                g_boolTabJoueur[tab_bytePosXYViaNom[0], tab_bytePosXYViaNom[1]] = true;

                // set la location de la picture box
                picBoxCavalier.Location = CtrlSender.Location;

                // check si le cavalier est déjà passé par la case
                if (CtrlSender.BackColor != Color.Green)
                {
                    CtrlSender.BackColor = Color.Green;
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

        private bool CheckPos(int intX, int intY)
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
                return ChangementBuffer(intX, intY);
            }
            else if (intX - TailleCase * 2 == g_intTabPosBufferXY[0] && intY + TailleCase * 1 == g_intTabPosBufferXY[1]) //  + 2x // + 1y
            {
                return ChangementBuffer(intX, intY);
            }
            else if (intX - TailleCase * 2 == g_intTabPosBufferXY[0] && intY - TailleCase * 1 == g_intTabPosBufferXY[1]) // + 2x // - 1y
            {
                return ChangementBuffer(intX, intY);
            }
            else if (intX - TailleCase * 1 == g_intTabPosBufferXY[0] && intY - TailleCase * 2 == g_intTabPosBufferXY[1]) // + 1x // - 2y
            {
                return ChangementBuffer(intX, intY);
            }
            // fin droite
            else if (intX + TailleCase * 1 == g_intTabPosBufferXY[0] && intY - TailleCase * 2 == g_intTabPosBufferXY[1]) // - 1x // - 2y
            {
                return ChangementBuffer(intX, intY);
            }
            else if (intX + TailleCase * 2 == g_intTabPosBufferXY[0] && intY - TailleCase * 1 == g_intTabPosBufferXY[1]) // - 2x // - 1y
            {
                return ChangementBuffer(intX, intY);
            }
            else if (intX + TailleCase * 2 == g_intTabPosBufferXY[0] && intY + TailleCase * 1 == g_intTabPosBufferXY[1]) // -2x + 1y
            {
                return ChangementBuffer(intX, intY);
            }
            else if (intX + TailleCase * 1 == g_intTabPosBufferXY[0] && intY + TailleCase * 2 == g_intTabPosBufferXY[1]) // - 1x + 2y
            {
                return ChangementBuffer(intX, intY);
            }
            // si non alors joueur clique sur mauvaise case
            else
            {
                return false;
            }
        }

        private bool ChangementBuffer(int intX, int intY)
        {
            // permet de compacter les lignes de codes qui revenait dans la méthode CheckPos
            g_intTabPosBufferXY[0] = intX;
            g_intTabPosBufferXY[1] = intY;

            return true;
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // fait disparaitre le cavalier en le disposant grace a foreach
            foreach (PictureBox item in g_ListePicBox)
            {
                item.Dispose();
            }

            // dispose cavalier
            picBoxCavalier.Dispose();

            // reset des variables
            g_intTabPosBufferXY = Array.Empty<int>();
            g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];
            g_boolTabCheckCavalierFini = Array.Empty<bool>();
            g_ListePicBox.Clear();

            // recall les fonctions, donc permet de refaire aparaitre le cavalier et l'echiquier
            DefPicBoxCavalier();
            Echiquer();

            // montre a l'user ce que il doit faire
            MessageBox.Show("Appuyez sur une case pour poser votre cavalier !");
        }

        private void Initialisation()
        {
            // re initalise le tableau du joueur
            g_boolTabJoueur = new bool[g_byteNbrCases, g_byteNbrCases];

            // active la visibilité des informations du cavalier
            labInfoCases.Visible = true;
            btnReset.Visible = true;
            panInfo.Visible = true;

            // desactive la visibilité de demande input nbr cases
            labNbrCases.Visible = false;
            txtBoxInputNbrCases.Visible = false;
            btnValiderNbrCases.Visible = false;

            // initialise l'echiquier
            DefPicBoxCavalier();
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
            // définitions
            Control CtrlSender = ((Control)sender);

            // set dans le buffer la position du click
            g_intTabPosBufferXY[0] = CtrlSender.Location.X;
            g_intTabPosBufferXY[1] = CtrlSender.Location.Y;

            // def de la position d'origine
            picBoxCavalier.Location = new Point(CtrlSender.Location.X, CtrlSender.Location.Y);

            // met la couleur la ou le joueur a cliqué en vert
            CtrlSender.BackColor = Color.Green;

            // set la location actuelle dans le tableau du joueur en trueM
            g_boolTabJoueur[CtrlSender.Location.X / CtrlSender.Width, CtrlSender.Location.Y / CtrlSender.Width] = true;

            // ajoute la picture box au cavalier
            panEchiquier.Controls.Add(picBoxCavalier);

            // permet d'ammener au premier plan le cavalier
            picBoxCavalier.BringToFront();

            // permet d'ajouter les event handler check pose et de retirer celui utilisé actuellement
            foreach (PictureBox item in g_ListePicBox)
            {
                item.Click += new EventHandler(InfoCase);
                item.Click += new EventHandler(PositionCavalier);
                item.Click -= PosCavalierViaClick;
            }
        }
    }
}
