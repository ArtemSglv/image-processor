using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_Processor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void convolutionButton_Click(object sender, EventArgs e)
        {
            double[,] win = new double[,]
            {
             {0.01, 0.02, 0.03, 0.04, 0.05},
             {-0.75,0,    0.2,  1,    -1},
             {0,    0,    -0.2, 1,    -1},
             {0,    -0.5, 0.2,  1,    -1},
             {0,    0,    -0.2, 1,    -1}
            };
            outputPictureBox.Image = ImageProcessor.Convolution((Bitmap)inputPictureBox.Image, 5, win);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            inputPictureBox.Image = new Bitmap("D:\\!my_work\\image-processor\\test.jpg");
        }
    }
}
