
namespace Cambios
{
    using Cambios.Modelos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;
    using Modelos;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            LoadRates();
        }

        private async void LoadRates()
        {
            //  bool load;
            ProgressBar.Value = 0;

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://rates.somee.com");

            var response = await client.GetAsync("/api/rates");
            var result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                MessageBox.Show(response.ReasonPhrase);
                return;
            }

            var rates = JsonConvert.DeserializeObject<List<Rate>>(result);

            ComboBoxOrigem.DataSource = rates;
            ComboBoxOrigem.DisplayMember = "Name";

            ComboBoxDestino.BindingContext = new BindingContext();

            ComboBoxDestino.DataSource = rates;
            ComboBoxDestino.DisplayMember = "Name";

            ProgressBar.Value = 100;
        }

    }
}
