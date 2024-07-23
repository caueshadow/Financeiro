using System;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaFinanceiro
{
    public partial class FrmMenu : Form
    {
        private string usuario;
        private Timer timer;

        public FrmMenu(string usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            pnlTopo.BackColor = Color.FromArgb(130, 83, 71);
            pnlDireita.BackColor = Color.FromArgb(100, 83, 71);

            label6.Text = usuario;
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
            label2.Text = DateTime.Now.ToString("dd/MM/yyyy");

            timer = new Timer();
            timer.Interval = 1000; // 1 segundo
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }

        private void telatóriosToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void MenuMovimentacoes_Click(object sender, EventArgs e) { }

        private void MenuSair_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void entradasESaídasToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void pnlTopo_Paint(object sender, PaintEventArgs e) { }

        private void label4_Click(object sender, EventArgs e) { }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void pnlDireita_Paint(object sender, PaintEventArgs e) { }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cadastros.FrmConsultar form = new Cadastros.FrmConsultar();
            form.ShowDialog();
        }

        private void entradasToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void label6_Click(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }
    }
}
