﻿using System;
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

            for (short y = 0; y < g_byteNbrCases; y++)
            {
                for (short x = 0; x < g_byteNbrCases; x++)
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

                    // permet d'afficher si l'user pointe une case légale
                    picBox.MouseEnter += new EventHandler(CheckPosCavalierViaSouris);

                    // reset la case quand l'user a fini de la pointer
                    picBox.MouseLeave += new EventHandler(ResetCaseSourisLeave);

                    // montre sur quel case l'user pointe quand il entre dedan avec la souris
                    picBox.MouseEnter += new EventHandler(InfoCase);

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
            PictureBox CtrlSender = (PictureBox)sender;

            // split le nom du picBox dans un tbl de string
            string[] tab_strStringNamePicBox = CtrlSender.Name.Split(' ');

            // permet de changer le nom du picBox en position XY dans le cavalier
            byte[] tab_bytePosXYViaNom = new byte[] { (byte)((byte)Convert.ToChar(tab_strStringNamePicBox[0]) - 65), Convert.ToByte(tab_strStringNamePicBox[1]) };

            // permet de reset la case quand l'user a cliqué dessus car : on entre dans la case et n'est jamais reset avec la méthode " ResetCaseSourisLeave "
            // si false, user jamais passé par la \|/ si true, user déjà passé par la
            if (g_boolTabJoueur[CtrlSender.Location.X / CtrlSender.Width, CtrlSender.Location.Y / CtrlSender.Width] == false)
            {
                CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.White : Color.Orange;
            }
            else
            {
                CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.Green : Color.DarkGreen;
            }

            // check si le joueur a cliqué sur une position valide
            if (CheckPos((short)CtrlSender.Location.X, (short)CtrlSender.Location.Y, (short)CtrlSender.Width))
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

        private bool CheckPos(short shortX, short shortY, short shortWidth)
        {
            // variables
            short shortTailleCase = (short)(panEchiquier.Width / g_byteNbrCases);
            short[] tabPosXY = new short[] { shortX, shortY };

            // ici le but est de voir par rapport a la case cliqué si le cavalier se trouve dessus
            // les commentaires montre ou le joueur doit cliquer pour que la condition soit true
            // la condition check par rapport a la case cliqué
            // mon point d'origine est en haut a gauche, donc le 0,0
            // check a chaque fois si le cavalier est dans une position légal
            if (shortX - shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                // fin droite
                shortX + shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 2 == g_shortTabPosBufferXY[1] )
            {
                    return ChangementBuffer(shortX, shortY, shortWidth);
            }
            // si non alors joueur clique sur mauvaise case
            else
            {
                return false;
            }
        }

        private bool ChangementBuffer(short shortX, short shortY, short shortWidth)
        {
            // permet d'enlever l'image du cavalier de la case précèdente
            g_ListePicBox[((((g_shortTabPosBufferXY[1] / shortWidth) + 1) * g_byteNbrCases) - (g_byteNbrCases - ((g_shortTabPosBufferXY[0] / shortWidth) + 1))) - 1].Image = null;

            // permet de compacter les lignes de codes qui revenait dans la méthode CheckPos
            g_shortTabPosBufferXY[0] = shortX;
            g_shortTabPosBufferXY[1] = shortY;

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
            g_shortTabPosBufferXY = new short[g_byteNbrCases * g_byteNbrCases];
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
            g_shortTabPosBufferXY[0] = (short)CtrlSender.Location.X;
            g_shortTabPosBufferXY[1] = (short)CtrlSender.Location.Y;

            // ckeck quel variation de couleur il doit mettre par rapport a la case ou le joueur a cliqué
            CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.Green : Color.DarkGreen;

            // set la location actuelle dans le tableau du joueur en trueM
            g_boolTabJoueur[CtrlSender.Location.X / CtrlSender.Width, CtrlSender.Location.Y / CtrlSender.Width] = true;

            // set l'echiquier sur la case cliqué
            CtrlSender.Image = g_imageCavalier;

            // permet d'ajouter les event handler check pose et de retirer celui utilisé actuellement
            foreach (PictureBox item in g_ListePicBox)
            {
                item.Click += new EventHandler(PositionCavalier);
                item.Click -= PosCavalierViaClick;
            }
        }

        private void CheckPosCavalierViaSouris(object sender, EventArgs e)
        {
            // variables
            PictureBox CtrlSender = ((PictureBox)sender);
            short shortX = (short)CtrlSender.Location.X;
            short shortY = (short)CtrlSender.Location.Y;
            short shortTailleCase = (short)CtrlSender.Width;

            // check si la souris est sur une position légal du cavalier, si true la met en vert clair \|/ si false la met en rouge
            if (shortX - shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX - shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                // fin droite
                shortX + shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY - shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 2 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 1 == g_shortTabPosBufferXY[1] ||
                shortX + shortTailleCase * 1 == g_shortTabPosBufferXY[0] && shortY + shortTailleCase * 2 == g_shortTabPosBufferXY[1] ||
                g_shortTabPosBufferXY[0] == -1 || g_shortTabPosBufferXY[1] == -1 )
            {
                CtrlSender.BackColor = Color.LightGreen;       
            }
            else
            {
                CtrlSender.BackColor = Color.Red;
            }
        }

        private void ResetCaseSourisLeave(object sender, EventArgs e)
        {
            // variables
            PictureBox CtrlSender = ((PictureBox)sender);

            // permet de reset la case quand l'user sort de la case
            // si false, user jamais passé par la \|/ si true, user déjà passé par la
            if (g_boolTabJoueur[CtrlSender.Location.X / CtrlSender.Width, CtrlSender.Location.Y / CtrlSender.Width] == false)
            {
                CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.White : Color.Orange;
            }
            else
            {
                CtrlSender.BackColor = ((CtrlSender.Location.X / CtrlSender.Width) + (CtrlSender.Location.Y / CtrlSender.Width)) % 2 == 0 ? Color.Green : Color.DarkGreen;
            }
        }
    }
}
