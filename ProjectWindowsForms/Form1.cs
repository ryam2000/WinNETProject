using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectLibrary;



namespace ProjectWindowsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataModel countryData = APIClass.GetCountries();

            if (countryData.Data != null)
            {
                foreach (var country in countryData.Data)
                {
                    comboBox1.Items.Add(country["country"]);
                }
            }
            else
            {
                MessageBox.Show("API data wasn't read on launch. Please start the application again in ~10 seconds.", "Critical error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox2.Items != null) comboBox2.Items.Clear();

            DataModel stateData = APIClass.GetStates(comboBox1.GetItemText(comboBox1.SelectedItem));

            if (stateData.Data != null)
            {
                foreach (var state in stateData.Data)
                {
                    comboBox2.Items.Add(state["state"]);
                }
            }
            else MessageBox.Show("It appears API data wasn't received properly. Try again in ~10 seconds.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox3.Items != null) comboBox3.Items.Clear();

            DataModel cityData = APIClass.GetCities(comboBox1.GetItemText(comboBox1.SelectedItem), comboBox2.GetItemText(comboBox2.SelectedItem));

            if (cityData.Data != null)
            {
                foreach (var city in cityData.Data)
                {
                    comboBox3.Items.Add(city["city"]);
                }
            }
            else MessageBox.Show("It appears API data wasn't received properly. Try again in ~10 seconds.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void comboBox3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            CityDataModel cityData = APIClass.GetCityData(comboBox1.GetItemText(comboBox1.SelectedItem), comboBox2.GetItemText(comboBox2.SelectedItem), comboBox3.GetItemText(comboBox3.SelectedItem));
            if (cityData.Data != null)
            {
                string aqiVal = cityData.Data.Current.Pollution.Aqius;
                string temp = cityData.Data.Current.Weather.Tp;
                string weather = cityData.Data.Current.Weather.Ic;

                label5.Text = aqiVal;
                switch (int.Parse(aqiVal))
                {
                    case int n when (n <= 33):
                        label6.Text = "Very Good";
                        label6.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        panel1.BackColor = Color.FromArgb(75, 205, 214);
                        break;
                    case int n when (n <= 66):
                        label6.Text = "Good";
                        label6.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        panel1.BackColor = Color.FromArgb(103, 214, 75);
                        break;
                    case int n when (n <= 99):
                        label6.Text = "Fair";
                        label6.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        panel1.BackColor = Color.FromArgb(207, 214, 75);
                        break;
                    case int n when (n <= 149):
                        label6.Text = "Poor";
                        label6.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        panel1.BackColor = Color.FromArgb(219, 137, 48);
                        break;
                    case int n when (n <= 200):
                        label6.Text = "Very Poor";
                        label6.ForeColor = Color.Black;
                        label5.ForeColor = Color.Black;
                        panel1.BackColor = Color.FromArgb(219, 74, 48);
                        break;
                    default:
                        label6.Text = "Hazardous";
                        label6.ForeColor = Color.White;
                        label5.ForeColor = Color.White;
                        panel1.BackColor = Color.FromArgb(102, 13, 27);
                        break;
                }
                switch (weather)
                {
                    case "01d":
                        label10.Text = "Clear sky";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(235, 233, 136);
                        break;
                    case "01n":
                        label10.Text = "Clear sky";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(29, 27, 71);
                        break;
                    case "02d":
                        label10.Text = "Few clouds";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(197, 207, 155);
                        break;
                    case "02n":
                        label10.Text = "Few clouds";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(29, 27, 71);
                        break;
                    case "03d":
                        label10.Text = "Scattered clouds";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(187, 196, 201);
                        break;
                    case "03n":
                        label10.Text = "Scattered clouds";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(95, 99, 102);
                        break;
                    case "04d":
                        label10.Text = "Broken clouds";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(187, 196, 201);
                        break;
                    case "04n":
                        label10.Text = "Broken clouds";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(95, 99, 102);
                        break;
                    case "09d":
                        label10.Text = "Shower rain";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(145, 191, 217);
                        break;
                    case "09n":
                        label10.Text = "Shower rain";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(74, 98, 112);
                        break;
                    case "10d":
                        label10.Text = "Rain";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(124, 199, 242);
                        break;
                    case "10n":
                        label10.Text = "Rain";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(39, 63, 77);
                        break;
                    case "11d":
                        label10.Text = "Thunderstorm";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(91, 199, 185);
                        break;
                    case "11n":
                        label10.Text = "Thunderstorm";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(49, 105, 93);
                        break;
                    case "13d":
                        label10.Text = "Snow";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(183, 232, 229);
                        break;
                    case "13n":
                        label10.Text = "Snow";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(80, 102, 101);
                        break;
                    case "50d":
                        label10.Text = "Mist";
                        label10.ForeColor = Color.Black;
                        label11.Text = "Daytime";
                        label11.ForeColor = Color.Black;
                        panel3.BackColor = Color.FromArgb(227, 230, 229);
                        break;
                    case "50n":
                        label10.Text = "Mist";
                        label10.ForeColor = Color.White;
                        label11.Text = "Nighttime";
                        label11.ForeColor = Color.White;
                        panel3.BackColor = Color.FromArgb(87, 89, 89);
                        break;
                }
                label9.Text = temp + "°C";
                switch (int.Parse(temp))
                {
                    case int n when (n < 0):
                        panel2.BackColor = Color.FromArgb(99, 216, 230);
                        break;
                    case int n when (n < 10):
                        panel2.BackColor = Color.FromArgb(164, 227, 116);
                        break;
                    case int n when (n < 20):
                        panel2.BackColor = Color.FromArgb(232, 202, 104);
                        break;
                    default:
                        panel2.BackColor = Color.FromArgb(232, 147, 104);
                        break;
                }
            }
            else
            {
                MessageBox.Show("It appears API data wasn't received properly. Try again in ~10 seconds.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
