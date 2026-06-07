
namespace Cambios
{
    using System.ComponentModel;
    using Cambios.Modelos;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Windows.Forms;
    using Modelos;
    using Cambios.Servicos;

    public partial class Form1 : Form
    {
        #region Atributos

        private List<Rate> Rates;

        private NetworkService networkService;

        private ApiService apiService;
        private DialogService dialogService;
        private DataService dataService;

        #endregion


        public Form1()
        {
            InitializeComponent();
            networkService = new NetworkService();
            apiService = new ApiService();
            dialogService = new DialogService();
            dataService = new DataService();
            LoadRates();
        }

        private async void LoadRates()
        {
            bool load;

            LabelResultado.Text = "A atualizar taxas... ";
            var connection = networkService.checkConnecion();

            if (!connection.IsSuccess)
            {
                LoadLocalRates();
                load = false;
            }
            else
            {
                await LoadApiRates();
                load = true;
            }

            if (Rates.Count == 0)
            {
                LabelResultado.Text = " Não há ligação á Internet" + Environment.NewLine +
                                      " e não foram préviamente carregadas as taxas." + Environment.NewLine +
                                      "Tente mais tarde!";

                LabelStatus.Text = "Primeira inicialização devera ser a ligação á internet";

                return;
            }

            ComboBoxOrigem.DataSource = Rates;
            ComboBoxOrigem.DisplayMember = "Name";

            //Corrige bug da microsoft
            ComboBoxDestino.BindingContext = new BindingContext();

            ComboBoxDestino.DataSource = Rates;
            ComboBoxDestino.DisplayMember = "Name";


           
            LabelResultado.Text = "Taxas atualizadas... ";

            if (load)
            {
                LabelStatus.Text = string.Format("Taxas carregadas da internet em {0:F}", DateTime.Now);
            }
            else
            {
                LabelStatus.Text = string.Format("Taxas carregadas da Base de Dados.");
            }

            ProgressBar.Value = 100;

            ButtonConverter.Enabled = true;
            BtnTroca.Enabled = true;

        }

        private void LoadLocalRates()
        {
           Rates = dataService.GetData();
        }

        private async Task LoadApiRates()
        {
            ProgressBar.Value = 0;

            var response = await apiService.GetRates("http://rates.somee.com", "/api/rates");

            Rates = (List<Rate>)response.Result;

            dataService.DeleteData();

            dataService.Savedata(Rates);
        }

        private void ButtonConverter_Click(object sender, EventArgs e)
        {
            Converter();
        }

        private void Converter()
        {
            if (string.IsNullOrEmpty(TextBoxValor.Text))
            {
                dialogService.ShowMessage("Erro", "Insira um valor a converter.");
                return;
            }

            decimal valor;
            if (!decimal.TryParse(TextBoxValor.Text, out valor))
            {
                dialogService.ShowMessage("Erro de conversão", "Valor terá que ser numérico");
                return;

            }

            if (ComboBoxOrigem.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem que escolher uma moeda a converter");
                return;
            }
            if (ComboBoxDestino.SelectedItem == null)
            {
                dialogService.ShowMessage("Erro", "Tem que escolher uma moeda de destino para converter");
                return;
            }
            var taxaOrigem = (Rate)ComboBoxOrigem.SelectedItem;
            var taxaDestino = (Rate)ComboBoxDestino.SelectedItem;

            var valorConvertido = valor / (decimal)taxaOrigem.TaxRate * (decimal)taxaDestino.TaxRate;

            LabelResultado.Text = string.Format("{0} {1:N2} = {2} {3:N2}", taxaOrigem.Code,
                valor, taxaDestino.Code, valorConvertido);
        }
        private void BtnTroca_Click(object sender, EventArgs e)
        {
            Troca();
        }

        private void Troca()
        {
            var aux = ComboBoxOrigem.SelectedItem;
            ComboBoxOrigem.SelectedItem = ComboBoxDestino.SelectedItem;
            ComboBoxDestino.SelectedItem = aux;
            Converter();
        }

    }
}
