using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace leves_form
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient client = new HttpClient();
        public Form1()
        {
            InitializeComponent();
        }

        private async void button_mentes_Click(object sender, EventArgs e)
        {
            try
            {
                string soupName = textBox_megnevezes.Text;
                string kaloria = textBox_kaloria.Text;
                string feherje = textBox_feherje.Text;
                string zsir = textBox_zsir.Text;
                string szenhidrat = textBox_szenhidrat.Text;
                string hamu = textBox_hamu.Text;
                string rost = textBox_rost.Text;

                string apiUrl = "http://localhost/_levesek_vizsgaszeru_/backendleves/index.php?leves";
                var values = new Dictionary<string, string>
                {
                    { "soupName", soupName },
                    { "kaloria", kaloria },
                    { "feherje", feherje },
                    { "zsir", zsir },
                    { "szenhidrat", szenhidrat },
                    { "hamu", hamu },
                    { "rost", rost }
                };
                var content = new FormUrlEncodedContent(values);
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                MessageBox.Show("Leves hozzáadva: " + soupName + "\nAdatok lekérve sikeresen.", "Mentés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(HttpRequestException ex)
            {
                MessageBox.Show("Hiba történt a kérés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
