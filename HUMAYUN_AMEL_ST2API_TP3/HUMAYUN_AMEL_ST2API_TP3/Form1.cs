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

namespace HUMAYUN_AMEL_ST2API_TP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // API key
        string APIKey = "aecfcdedd663737cb5055aabf60844f3";
        string latitude = "";
        string longitude = "";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            getWeather();
            getForcast();
            getAir();
        }
        

        void getWeather()
        {
            using (WebClient web = new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}", CityO.Text, APIKey);
                var json = web.DownloadString(url);

                WeatherInfo.Root myDeserializedClass = JsonConvert.DeserializeObject<WeatherInfo.Root>(json);

                picIcon.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.weather[0].icon + ".png";
                Condition.Text = myDeserializedClass.weather[0].main;

                // Sun(rise)set in UTC
                Sunset.Text = convertDateTime(myDeserializedClass.sys.sunset).ToShortTimeString();
                Sunrise.Text = convertDateTime(myDeserializedClass.sys.sunrise).ToShortTimeString();

                // Humidity in %
                int humidity = myDeserializedClass.main.humidity;
                Humidity.Text = humidity.ToString() + " %";

                // Pressure
                int pressure = myDeserializedClass.main.pressure;
                Pressure.Text = pressure.ToString() + " hPa";

                // Wind
                double speed = ConvertSpeed(myDeserializedClass.wind.speed);
                double sp = Convert.ToInt32(speed);
                Speed.Text = speed.ToString() + " km/h ";

                // Temperature
                double temperature = ConvertKC(myDeserializedClass.main.temp);
                double temps = Convert.ToInt32(temperature);
                temp.Text = temps.ToString() + " °C ";

                // Take the lat
                latitude = myDeserializedClass.coord.lat.ToString();
                // Take the lon
                longitude = myDeserializedClass.coord.lon.ToString();
            }           
        }

        public string DisplayAirquality(int num)
        {
            if (num == 1)
            {
                string good = "The air quality is GOOD";
                return good;
            }
            else if (num ==2)
            {
                string fair = "The air quality is FAIR";
                return fair;
            }
            else if (num == 3)
            {
                string moderate = "The air quality is MODERATE";
                return moderate;
            }
            else if (num == 4)
            {
                string poor = "The air quality is POOR";
                return poor;
            }
            else
            {
                string vpoor = "The air quality is VERY POOR";
                return vpoor;
            }
        }

        void getAir()
        {
            using (WebClient web2 = new WebClient())
            {
                string url3 = string.Format("http://api.openweathermap.org/data/2.5/air_pollution?lat={0}&lon={1}&appid={2}", latitude, longitude, APIKey);
                var json3 = web2.DownloadString(url3);

                AirPollution.Root myDeserializedClass3 = JsonConvert.DeserializeObject<AirPollution.Root>(json3);
                int aqi = myDeserializedClass3.list[0].main.aqi;
                air.Text= DisplayAirquality(aqi);
            } 
        }
        void getForcast()
        {
            using (WebClient web = new WebClient())
            {
                string url2 = string.Format("http://api.openweathermap.org/data/2.5/forecast?q={0}&APPID={1}", CityO.Text, APIKey);
                var json2 = web.DownloadString(url2);

                WeatherForcast.Root myDeserializedClass = JsonConvert.DeserializeObject<WeatherForcast.Root>(json2);
               

                day1.Text = string.Format("{0}", getDate(myDeserializedClass.list[8].dt).DayOfWeek);
                double tempera1 = ConvertKC(myDeserializedClass.list[2].main.temp_min);
                double tempe1 = Convert.ToInt32(tempera1);
                T1m.Text = tempe1.ToString() + " °C ";
                double tempera1max = ConvertKC(myDeserializedClass.list[8].main.temp_max);
                double tempe1max = Convert.ToInt32(tempera1max);
                t1max.Text = tempe1max.ToString() + " °C ";
                pictureBox1.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.list[8].weather[0].icon + ".png";


                day2.Text = string.Format("{0}", getDate(myDeserializedClass.list[16].dt).DayOfWeek);
                double tempera2 = ConvertKC(myDeserializedClass.list[10].main.temp_min);
                double tempe2 = Convert.ToInt32(tempera1);
                min2.Text = tempe1.ToString() + " °C ";
                double tempera2max = ConvertKC(myDeserializedClass.list[16].main.temp_max);
                double tempe2max = Convert.ToInt32(tempera2max);
                max2.Text = tempe1max.ToString() + " °C ";
                pictureBox2.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.list[16].weather[0].icon + ".png";
                
                day3.Text = string.Format("{0}", getDate(myDeserializedClass.list[24].dt).DayOfWeek);
                double tempera3 = ConvertKC(myDeserializedClass.list[18].main.temp_min);
                double tempe3 = Convert.ToInt32(tempera3);
                min3.Text = tempe3.ToString() + " °C ";
                double tempera3max = ConvertKC(myDeserializedClass.list[24].main.temp_max);
                double tempe3max = Convert.ToInt32(tempera3max);
                max3.Text = tempe3max.ToString() + " °C ";
                pictureBox3.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.list[24].weather[0].icon + ".png";

                day4.Text = string.Format("{0}", getDate(myDeserializedClass.list[34].dt).DayOfWeek);
                double tempera4 = ConvertKC(myDeserializedClass.list[26].main.temp_min);
                double tempe4 = Convert.ToInt32(tempera3);
                min4.Text = tempe4.ToString() + " °C ";
                double tempera4max = ConvertKC(myDeserializedClass.list[34].main.temp_max);
                double tempe4max = Convert.ToInt32(tempera4max);
                max4.Text = tempe4max.ToString() + " °C ";
                pictureBox4.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.list[34].weather[0].icon + ".png";

                day5.Text = string.Format("{0}", getDate(myDeserializedClass.list[39].dt).DayOfWeek);
                double tempera5 = ConvertKC(myDeserializedClass.list[36].main.temp_min);
                double tempe5 = Convert.ToInt32(tempera5);
                min5.Text = tempe5.ToString() + " °C ";
                double tempera5max = ConvertKC(myDeserializedClass.list[34].main.temp_max);
                double tempe5max = Convert.ToInt32(tempera5max);
                max5.Text = tempe5max.ToString() + " °C ";
                pictureBox5.ImageLocation = "https://openweathermap.org/img/w/" + myDeserializedClass.list[39].weather[0].icon + ".png";
            }
        }

        DateTime getDate(double millisecound)
        {
            DateTime day = new System.DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc).ToLocalTime();
            day = day.AddSeconds(millisecound).ToLocalTime();
            return day;
        }

        DateTime convertDateTime(long millisec)
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
