﻿using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Forms;

namespace Test.UC
{
    public partial class DoughnutExample : Form
    {
        public DoughnutExample()
        {
            InitializeComponent();

            pieChart1.InnerRadius = 100;
            pieChart1.LegendLocation = LegendLocation.Right;

            pieChart1.Series = new SeriesCollection
            {
                new PieSeries
                {
                    Title = "Chrome",
                    Values = new ChartValues<double> {8},
                    PushOut = 15,
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Mozilla",
                    Values = new ChartValues<double> {6},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Opera",
                    Values = new ChartValues<double> {10},
                    DataLabels = true
                },
                new PieSeries
                {
                    Title = "Explorer",
                    Values = new ChartValues<double> {4},
                    DataLabels = true
                }
            };
        }

        private void DoughnutExample_Load(object sender, System.EventArgs e)
        {

        }
    }
}
