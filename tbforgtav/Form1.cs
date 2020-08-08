using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoItX3Lib;

namespace tbforgtav
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll")] // I love getasynckeystate
        static extern short GetAsyncKeyState(Keys vkey);


        object pixel;

        int newCol;
        int[] coor = { 960, 540 }; // works for 1920x1080 only 

        AutoItX3 au3 = new AutoItX3();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Thread mn = new Thread(Main) { IsBackground = true };
            mn.Start();
        }
        int GrabColor()
        {
            pixel = au3.PixelGetColor(coor[0], coor[1]); // THIS ONLY WORKS FOR 1920x1080 YOU HAVE TO SET YOUR OWN COORDINATES PEDENDING ON YOUR SCREEN RESOLUTION.
           return Int32.Parse(pixel.ToString());
            
        }
        private void Main()
        {
            while (true)
            {
                if (GetAsyncKeyState(Keys.XButton2) < 0) // Change the hotkey to whatever you want, mouse5 is just my fav.
                {
                    newCol = GrabColor();

                    if (newCol != 14737632)
                    {
                        au3.MouseClick("LEFT");
                    }
                    
                }
                Thread.Sleep(10);
            }
        }
    }
}
