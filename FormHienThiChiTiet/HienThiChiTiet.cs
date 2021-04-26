using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Viva_vegan.ClassCSharp;

namespace Viva_vegan
{
    public partial class HienThiChiTiet : Form
    {
        private MonAn monan;
        private Byte[] imgByte;
        public HienThiChiTiet(Byte[] imgByteTransferred = null)
        {
            InitializeComponent();
            imgByte = imgByteTransferred;
            MemoryStream stream = new MemoryStream(imgByte);
            picBoxZoom.Image = Image.FromStream(stream);
        }
    }
}
