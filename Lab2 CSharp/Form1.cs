using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2_CSharp
{
    public partial class Form1: Form
    {
        private double relationOfWidth;
        private double relationOfDistanceBetweenPictureBoxes;
        private double relationOfHeight;
        private int initDistanceBetweenPictureboxes;
        private int distanceBetweenPictureboxAndButton;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initDistanceBetweenPictureboxes       = PBAfter.Left   - PBBefore.Right;
            distanceBetweenPictureboxAndButton    = ButtonLoad.Top - PBBefore.Bottom;
            relationOfDistanceBetweenPictureBoxes = (double) initDistanceBetweenPictureboxes / Width;
            relationOfWidth = ((double) PBBefore.Width / Width - relationOfDistanceBetweenPictureBoxes) *
                              1.07; // 1.07 - костыль. Неплохо работает.
            relationOfHeight = (double) PBBefore.Height / Height;
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            PBBefore.Size = new Size((int) (Width * relationOfWidth), (int) (Height * relationOfHeight));
            PBAfter.Left  = (int) (PBBefore.Right + Width * relationOfDistanceBetweenPictureBoxes);
            PBAfter.Size  = PBBefore.Size;

            ButtonLoad.Top = ButtonProcess.Top =
                ProgressBar.Top = PBBefore.Bottom + distanceBetweenPictureboxAndButton;
            ButtonProcess.Left = PBBefore.Right - ButtonProcess.Width;

            ProgressBar.Left  = PBAfter.Left;
            ProgressBar.Width = PBAfter.Width;

            LabelBefore.Left = (PBBefore.Left + PBBefore.Right) / 2 - LabelBefore.Width / 2;
            LabelAfter.Left  = (PBAfter.Left  + PBAfter.Right)  / 2 - LabelAfter.Width  / 2;
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            //MessageBox.Show(Size.ToString());
        }

        private void ButtonLoad_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter =
                    @"Файлы изображений (*.gif; *.jpg; *.jpeg; *.bmp; *.wmf; *.png)|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png",
                Multiselect = false
            };

            if (! (dialog.ShowDialog() is DialogResult.OK))
            {
                return;
            }

            try
            {
                var image = Image.FromFile(dialog.FileName);
                PBBefore.Image = image;
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show(@"Неверный формат изображения. Возможно, изображение повреждено.");
            }
        }

        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private void ButtonProcess_Click(object sender, EventArgs e)
        {
            #region Declaration of locals

            var bmapInit   = PBBefore.Image as Bitmap; // только для чтения здесь
            var bmapResult = new Bitmap(bmapInit.Width, bmapInit.Height);
            var tablePixelTuples =
                new (byte R, byte G, byte B)[bmapInit.Width, bmapInit.Height]; // Обращение: [x, y]  >^
            // Такс, кортеж - что-то вроде литерала
            int Rmin = 0,
                Rmax = 0;
            int Gmin = 0,
                Gmax = 0;
            int Bmin = 0,
                Bmax = 0;
            var GistogramR = new List<(int X, int Y)>[256]; //от 0 до 255 включительно
            var GistogramG = new List<(int X, int Y)>[256];
            var GistogramB = new List<(int X, int Y)>[256];
            var ResultsR   = new byte[256]; //Значение функции будет от 0 до 255
            var ResultsG   = new byte[256]; //Значение функции будет от 0 до 255
            var ResultsB   = new byte[256]; //Значение функции будет от 0 до 255

            #endregion

            InitLocals();

            Init_GistogramsThenMaxesAndMins();

            #region Init arrays of results

            double multiplierR = 255 / (double) (Rmax - Rmin);
            double multiplierG = 255 / (double) (Gmax - Gmin);
            double multiplierB = 255 / (double) (Bmax - Bmin);

            Init_Arrays_Of_Results();

            #endregion

            #region Init table of result
            // в гистограммах у меня находятся точки. В массивах результатов у меня значение для каждого столбца. 
            // я прохожу по гистограмме, и для каждой точки в столбце ставлю R или G или B из массива результата.


            #endregion


            void InitLocals()
            {
                for (var i = 0; i < GistogramR.Length; i++)
                {
                    GistogramR[i] = new List<(int X, int Y)>(bmapInit.Width);
                }

                for (var i = 0; i < GistogramG.Length; i++)
                {
                    GistogramG[i] = new List<(int X, int Y)>(bmapInit.Width);
                }

                for (var i = 0; i < GistogramB.Length; i++)
                {
                    GistogramB[i] = new List<(int X, int Y)>(bmapInit.Width);
                }
            }

            void Init_GistogramsThenMaxesAndMins()
            {
                for (var j = 0; j < bmapInit.Height; j++)
                {
                    for (var i = 0; i < bmapInit.Width; i++)
                    {
                        var c = bmapInit.GetPixel(i, j);
                        tablePixelTuples[i, j] = (c.R, c.G, c.B); // [x,y] = color
                        GistogramR[c.R]
                            .Add((i, j)); // так, мне нужно добавить тут именно 2д точку, т.е. xy, т.е. то же, что в цвете.
                        GistogramG[c.G].Add((i, j));
                        GistogramB[c.B].Add((i, j));
                    }
                }

                for (var i = 0; i < GistogramR.Length; i++)
                {
                    if (GistogramR[i].Count > 0)
                    {
                        Rmin = i;
                        break;
                    }
                }

                for (var i = GistogramR.Length - 1; i >= 0; i--)
                {
                    if (GistogramR[i].Count > 0)
                    {
                        Rmax = i;
                        break;
                    }
                }

                for (var i = 0; i < GistogramG.Length; i++)
                {
                    if (GistogramG[i].Count > 0)
                    {
                        Gmin = i;
                        break;
                    }
                }

                for (var i = GistogramG.Length - 1; i >= 0; i--)
                {
                    if (GistogramG[i].Count > 0)
                    {
                        Gmax = i;
                        break;
                    }
                }

                for (var i = 0; i < GistogramB.Length; i++)
                {
                    if (GistogramB[i].Count > 0)
                    {
                        Bmin = i;
                        break;
                    }
                }

                for (var i = GistogramB.Length - 1; i >= 0; i--)
                {
                    if (GistogramB[i].Count > 0)
                    {
                        Bmax = i;
                        break;
                    }
                }
            }

            void Init_Arrays_Of_Results()
            {
                for (var i = 0; i < ResultsR.Length; i++)
                {
                    if (GistogramR[i].Count is 0)
                    {
                        return;
                    }

                    var x      = tablePixelTuples[GistogramR[i][0].X, GistogramR[i][0].Y].R;
                    var result = (int) ((x - Rmin) * multiplierR);
                    if (result > 255 ||
                        result < 0)
                    {
                        throw new ArgumentException("результат формулы не вмещается в байт");
                    }

                    ResultsR[i] =
                        (byte) result; // хм. X не может быть меньше минимального значения. Может, все и в порядке.
                }

                for (var i = 0; i < ResultsG.Length; i++)
                {
                    if (GistogramG[i].Count is 0)
                    {
                        return;
                    }

                    var x      = tablePixelTuples[GistogramG[i][0].X, GistogramG[i][0].Y].G;
                    var result = (int) ((x - Gmin) * multiplierG);
                    if (result > 255 ||
                        result < 0)
                    {
                        throw new ArgumentException("результат формулы не вмещается в байт");
                    }

                    ResultsG[i] =
                        (byte) result; // хм. X не может быть меньше минимального значения. Может, все и в порядке.
                }

                for (var i = 0; i < ResultsB.Length; i++)
                {
                    if (GistogramB[i].Count is 0)
                    {
                        return;
                    }

                    var x      = tablePixelTuples[GistogramB[i][0].X, GistogramB[i][0].Y].B;
                    var result = (int) ((x - Bmin) * multiplierB);
                    if (result > 255 ||
                        result < 0)
                    {
                        throw new ArgumentException("результат формулы не вмещается в байт");
                    }

                    ResultsB[i] =
                        (byte) result; // хм. X не может быть меньше минимального значения. Может, все и в порядке.
                }
            }
        }
    }

    struct StructForType
    {
        public byte R;
        public byte G;
        public byte B;
    }
}