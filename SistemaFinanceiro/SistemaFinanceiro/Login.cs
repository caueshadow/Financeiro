using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace SistemaFinanceiro
{
    public partial class FrmLogin : Form
    {
        private SqlConnection connection;

        public FrmLogin()
        {
            InitializeComponent();
            pnlLogin.Visible = false;

            // Configuração da conexão com o banco de dados
            string connectionString = "Data Source=SEU_SERVIDOR;Initial Catalog=SEU_BANCO_DE_DADOS;Integrated Security=True";
            connection = new SqlConnection(connectionString);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
            pnlLogin.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            ChamarLogin();
        }

        private void pnlLogin_Paint(object sender, PaintEventArgs e) { }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChamarLogin();
            }
        }

        private void ChamarLogin()
        {
            if (txtUsuario.Text == "" || txtSenha.Text == "")
            {
                MessageBox.Show("Preencha os Campos Corretamente");
                txtUsuario.Focus();
                return;
            }

            string usuario = ValidarLogin(txtUsuario.Text, txtSenha.Text);
            if (!string.IsNullOrEmpty(usuario))
            {
                FrmMenu form = new FrmMenu(usuario);
                Limpar();
                form.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos.");
                txtUsuario.Focus();
            }
        }

        private string ValidarLogin(string usuario, string senha)
        {
            try
            {
                string query = "SELECT Nome FROM Usuarios WHERE Usuario=@usuario AND Senha=@senha";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    connection.Open();
                    object result = cmd.ExecuteScalar();
                    connection.Close();

                    return result?.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao banco de dados: " + ex.Message);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void Limpar()
        {
            txtUsuario.Text = "";
            txtSenha.Text = "";
            txtUsuario.Focus();
        }

        private void FrmLogin_Activated(object sender, EventArgs e) { }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            pnlLogin.Location = new Point(this.Width / 2 - 166, this.Height / 2 - 170);
        }

        private void txtSenha_TextChanged(object sender, EventArgs e) { }
    }
}
