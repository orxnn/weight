using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace weight
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtWeight.Text, out double ceki) || ceki <= 0)
            {
                MessageBox.Show("Zəhmət olmasa düzgün çəki daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double boy) || boy <= 0)
            {
                MessageBox.Show("Zəhmət olmasa düzgün boy daxil edin!", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (boy > 3)
            {
                boy /= 100.0;
            }

            double bki = ceki / (boy * boy);

            
            button4.Text = $"BKİ: {bki:F2}";

            string status = "";
            string risk = "";
            string imageName = "";

            if (bki < 18.5)
            {
                status = "Çəki azlığı (Arıq)";
                risk = "İmmunitet zəifliyi, qida çatışmazlığı riski";
                imageName = "Underweight.png";
            }
            else if (bki >= 18.5 && bki <= 24.9)
            {
                status = "Normal çəki";
                risk = "Minimum risk (İdeal status)";
                imageName = "normal.png";
            }
            else if (bki >= 25.0 && bki <= 32.0)
            {
                status = "Artıq çəki";
                risk = "Ürək-damar və şəkər xəstəliyi riski artır";
                imageName = "Overweight.png";
            }
            else if (bki >= 33.0 && bki <= 39.0)
            {
                status = "I dərəcəli piylənmə";
                risk = "Yüksək tibbi risk";
                imageName = "obez.png";
            }
            else
            {
                status = "III dərəcəli (Morbid) piylənmə";
                risk = "Həyati təhlükəli risk";
                imageName = "morbid.jpg";
            }

            lblStatus.Text = $"Çəki Statusu: {status}";
            lblRisk.Text = $"Sağlamlıq Riski: {risk}";

            LoadStatusImage(imageName);
        }

        private void LoadStatusImage(string imageName)
        {
            try
            {
                string imagePath = Path.Combine(Application.StartupPath, "Images", imageName);

                if (File.Exists(imagePath))
                {
                    pictureBoxStatus.Image = Image.FromFile(imagePath);
                    pictureBoxStatus.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    pictureBoxStatus.Image = null;
                }
            }
            catch
            {
                pictureBoxStatus.Image = null;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
