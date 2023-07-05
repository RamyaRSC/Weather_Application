using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;


namespace Weather_Application
{ 
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string APIKey = "63c73eeffa9329e72b1a57dc03d7cdfc";

        private void btnSearch_Click(object sender, EventArgs e)
        {
            GetWeather();
        }
        void GetWeather()
        {
            using(WebClient web =  new WebClient())
            {
                string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q={0}&appid={1}&units=metric", TBCity.Text, APIKey);
                var json = web.DownloadString(url);
                WeatherInfo.root Info = JsonConvert.DeserializeObject<WeatherInfo.root>(json);

                picIcon.ImageLocation = "https://api.openweathermap.org/img/w/" + Info.weather[0].icon + ".png";

                labCondition.Text = Info.weather[0].main;
                labDetails.Text = Info.weather[0].description;
                labSunrise.Text = Info.sys.sunrise.ToString();
                labSunset.Text = Info.sys.sunset.ToString();

                labWindSpeed.Text = Info.wind.speed.ToString();
                labPressure.Text = Info.main.pressure.ToString();

                labTemp.Text = Info.main.temp.ToString() + "\u00B0C";
                labName.Text = Info.name.ToString();

            }
        }       
    }

}
