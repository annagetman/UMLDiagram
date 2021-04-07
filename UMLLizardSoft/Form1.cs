﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using UMLLizardSoft.Arrows;

namespace UMLLizardSoft
{
    public partial class Form1 : Form
    {
        Bitmap _mainBitmap;
        Bitmap _tmpBitmap;
        Graphics _graphics;
        bool _isButtonPressed = false;

        AbstractArrow _crntArrow;

        int arrowWeight;
        Pen _pen = new Pen(Color.Black , 3);
        //Pen _penEnd;


        //Point _pointFirst;
        //Point _pointSecond;

        //int x1, y1, x2, y2;

        //private delegate void DrawArrow(Pen _pen, int x1, int y1, int x2, int y2);
        //DrawArrow drawArrow;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //_mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            //_penEnd = new Pen(Color.Red, arrowWeight);                        //Line width of "Implimentation" ArrowBody !ONLY!
            //_pen = new Pen(Color.Red, arrowWeight);                           //line width of otherwise
            //_graphics = Graphics.FromImage(_mainBitmap);
            //_graphics.Clear(Color.White);
            //pictureBox1.Image = _mainBitmap;
            //drawArrow = addArrowAsotiation;                     //initialValue
            //arrowWeight = 1;

            _mainBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            _graphics = Graphics.FromImage(_mainBitmap);
            _graphics.Clear(Color.White);
            pictureBox1.Image = _mainBitmap;

            _crntArrow = new ArrowAssociation();

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            _crntArrow.StartPoint = e.Location;
            _isButtonPressed = true;
            ////inputAquired!
            //_isButtonPressed = true;
            //x1 = e.X;
            //y1 = e.Y;
            //_pointFirst = new Point(x1, y1);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            _isButtonPressed = false;
            _mainBitmap = _tmpBitmap;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isButtonPressed)
            {
                _tmpBitmap = (Bitmap)_mainBitmap.Clone();
                _graphics = Graphics.FromImage(_tmpBitmap);

                _crntArrow.EndPoint = e.Location;

                _crntArrow.Draw(_graphics);

                pictureBox1.Image = _tmpBitmap;
                GC.Collect();
            }
            //if (_isButtonPressed)
            //{
            //    x2 = e.X;
            //    y2 = e.Y;
            //    _pointSecond = new Point(x2, y2);

            //    _tmpBitmap = (Bitmap)_mainBitmap.Clone();
            //    _graphics = Graphics.FromImage(_tmpBitmap);

            //    drawArrow.Invoke(_pen, x1, y1, x2, y2);                             //correctDrawings

            //    pictureBox1.Image = _tmpBitmap;
            //    GC.Collect();
            //}
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            _crntArrow = new ArrowAssociation();                                                //changeValue
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            _crntArrow = new ArrowInheritance();                                                 //changeValue
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            _crntArrow = new ArrowAggregation();                                                 //changeValue
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            _crntArrow = new ArrowСomposition();                                                 //changeValue
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            _crntArrow = new ArrowImplementation();                                              //changeValue
        }

        //public void AddRectangle(Pen _pen, int firstPoint, int secondPoint)
        //{
        //    int W = x2 - x1;
        //    int H = y2 - y1;

        //    _graphics.DrawRectangle(_pen, x1, y1, W, H);
        //}

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            TrackBar bar = (TrackBar)sender;
            int minWeightValue = bar.Minimum;
            int maxWeitghValue = bar.Maximum;
            int value = bar.Value;
            arrowWeight = 1 + minWeightValue + value;
            //_penEnd = new Pen(_pen.Color, arrowWeight);                        //Line width of "Implimentation" ArrowBody !ONLY!
            _pen = new Pen(_pen.Color, arrowWeight);                           //line width of otherwise
            bar.SetRange(1, 5);                                               //was 4 --> 1-5

        }

        private void buttonColorPalette_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            buttonColorPalette.BackColor = colorDialog1.Color;
            _pen.Color = colorDialog1.Color;
        }

        //public void AddRectangle1(Pen _pen, int firstPoint, int secondPoint)
        //{
        //    int W = x2 - x1;
        //    int H = y2 - y1;

        //    _graphics.DrawRectangle(_pen, x1, y1, W, H);
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.2));
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.5));
        //}

        //public void AddRectangle2(Pen _pen, int firstPoint, int secondPoint)
        //{
        //    int W = x2 - x1;
        //    int H = y2 - y1;

        //    _graphics.DrawRectangle(_pen, x1, y1, W, H);
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.2));
        //}

        //public void AddRectangle3(Pen _pen, int firstPoint, int secondPoint)
        //{
        //    int W = x2 - x1;
        //    int H = y2 - y1;

        //    _graphics.DrawRectangle(_pen, x1, y1, W, H);
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.2));
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.5));
        //    _graphics.DrawRectangle(_pen, x1, y1, W, (int)(H * 0.8));
        //}
    }
}
