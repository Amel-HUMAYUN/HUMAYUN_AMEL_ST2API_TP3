using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;

namespace HUMAYUN_AMEL_ST2API_TP2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // API key
        string APIKey = "aecfcdedd663737cb5055aabf60844f3";

        // Interface graphique
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Ville
        private void label1_Click(object sender, EventArgs e)
        {

        }
        
        // button search
        private void button2_Click(object sender, EventArgs e) 
        {
            getWeather();
            getForcast();

        }

        // barre de recherche
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        // Condition
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        

        private void Sunset_Click(object sender, EventArgs e)
        {

        }

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", CityO.Text, APIKey);
                var json = web.DownloadString(url);

                Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(json);

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.Weather[0].icon + ".png";
                Condition.Text = myDeserializedClass.Weather[0].main;

                // Sun(rise)set in UTC
                Sunset.Text = convertDateTime(myDeserializedClass.Sys.sunset).ToShortTimeString();
                Sunrise.Text = convertDateTime(myDeserializedClass.Sys.sunrise).ToShortTimeString();

                // Humidity in %
                int humidity = myDeserializedClass.Main.humidity;
                Humidity.Text = humidity.ToString() + " %";

                // Pressure
                int pressure = myDeserializedClass.Main.pressure;
                Pressure.Text = pressure.ToString() + " hPa";

                // Wind
                double speed = ConvertSpeed(myDeserializedClass.Wind.speed);
                double sp = Convert.ToInt32(speed);
                Speed.Text = speed.ToString() + " km/h ";

                // Temperature
                double temperature = ConvertKC(myDeserializedClass.Main.temp);
                double temps = Convert.ToInt32(temperature);
                temp.Text = temps.ToString() + " °C ";
            }
        }

        void getForcast()
        {
            using (WebClient web = new WebClient())
            {
                string url2 = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}", CityO.Text, APIKey);
                var json2 = web.DownloadString(url2);
                
                Root2 myDeserializedClass2 = JsonConvert.DeserializeObject<Root2>(json2);

                Root2 root2 = myDeserializedClass2;

                day1.Text = string.Format("{0}", getDate(root2.list[8].dt).DayOfWeek);
                double tempera1 = ConvertKC(root2.list[8].main.temp);
                double tempe1 = Convert.ToInt32(tempera1);
                temp1.Text = tempe1.ToString() + " °C ";
                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + root2.list[8].weather[0].icon + ".png";
                

                day2.Text = string.Format("{0}", getDate(root2.list[16].dt).DayOfWeek);
                double tempera2 = ConvertKC(root2.list[16].main.temp);
                double tempe2 = Convert.ToInt32(tempera2);
                temp2.Text = tempe2.ToString() + " °C ";
                pictureBox2.ImageLocation = "https://openweathermap.org/img/w/" + root2.list[16].weather[0].icon + ".png";

                day3.Text = string.Format("{0}", getDate(root2.list[24].dt).DayOfWeek);
                double tempera3 = ConvertKC(root2.list[24].main.temp);
                double tempe3 = Convert.ToInt32(tempera3);
                temp3.Text = tempe3.ToString() + " °C ";
                pictureBox3.ImageLocation = "https://openweathermap.org/img/w/" + root2.list[24].weather[0].icon + ".png";

                day4.Text = string.Format("{0}", getDate(root2.list[34].dt).DayOfWeek);
                double tempera4 = ConvertKC(root2.list[34].main.temp);
                double tempe4 = Convert.ToInt32(tempera4);
                temp4.Text = tempe2.ToString() + " °C ";
                pictureBox4.ImageLocation = "https://openweathermap.org/img/w/" + root2.list[34].weather[0].icon + ".png";

                day5.Text = string.Format("{0}", getDate(root2.list[39].dt).DayOfWeek);
                double tempera5 = ConvertKC(root2.list[39].main.temp);
                double tempe5 = Convert.ToInt32(tempera5);
                temp5.Text = tempe5.ToString() + " °C ";
                pictureBox5.ImageLocation = "https://openweathermap.org/img/w/" + root2.list[39].weather[0].icon + ".png";
            }
        }

        DateTime getDate(double millisecound)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecound).ToLocalTime();
            return day;
        }

        DateTime convertDateTime (long millisec)
        {
            DateTime day = new DateTime(2022, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisec).ToLocalTime();
            day = day.AddHours(1);
            return day;
        }

        public double ConvertKC(double a) // Kelvin en Celsius
        {
            double c = 273.15;
            double tempe = a - c;
            return tempe;
        }

        public double ConvertSpeed(double a) // Kelvin en Celsius
        {
            double k = 3.6;
            double speedk = a * k;
            return speedk;
        }


        private void Sunrise_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click_2(object sender, EventArgs e)
        {
           
        }

        private void Humidity_Click(object sender, EventArgs e)
        {

        }

        private void temp1_Click(object sender, EventArgs e)
        {
            
        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }
        // scroll bar
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}
