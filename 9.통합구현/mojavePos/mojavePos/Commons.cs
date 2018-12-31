﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace mojavePos
{
    class Commons
    {
        public Panel getPanel(Hashtable hashtable)
        {
            Panel panel = new Panel();
            panel.Size = (Size)hashtable["size"];
            panel.Location = (Point)hashtable["point"];
            panel.BackColor = (Color)hashtable["color"];
            panel.Name = hashtable["name"].ToString(); 
            return panel;//
        }

        public Button getButton(Hashtable hashtable)
        {
            Button btn = new Button();
            btn.Size = (Size)hashtable["size"];
            btn.Location = (Point)hashtable["point"];
            btn.BackColor = (Color)hashtable["color"];
            btn.Name = hashtable["name"].ToString();
            btn.Text = hashtable["text"].ToString();
            btn.Click += (EventHandler)hashtable["click"];
            return btn;
        }

        public Label getLabel(Hashtable hashtable)
        {
            Label label = new Label();
            label.Location = (Point)hashtable["point"];
            label.BackColor = (Color)hashtable["color"];
            label.Name = hashtable["name"].ToString();
            label.Text = hashtable["text"].ToString();
            return label;
        }
        public Chart getChart(Hashtable hashtable, Control parentDomain)
        {
            Chart chart = new Chart();
            ChartArea chartArea1 = new ChartArea();
            Legend legend1 = new Legend();
            Series series1 = new Series();

            chartArea1.Name = hashtable["areaname"].ToString();
            legend1.Name = hashtable["legname"].ToString();
            series1.ChartArea = hashtable["areaname"].ToString();
            series1.ChartType = SeriesChartType.Doughnut;
            series1.Legend = hashtable["legname"].ToString();
            series1.Name = hashtable["seriname"].ToString();
            // 차트 기본
            chart.Name = hashtable["chartname"].ToString();
            chart.Dock = DockStyle.Fill;
            chart.Text = hashtable["text"].ToString();
            chart.ChartAreas.Add(chartArea1);
            chart.Legends.Add(legend1);
            chart.Series.Add(series1);
            chart.Series[series1.Name].IsValueShownAsLabel = true;

            parentDomain.Controls.Add(chart);
            return chart;
        }
        public ComboBox getComboBox(Hashtable hashtable)
        {
            ComboBox comboBox = new ComboBox();
            comboBox.Width = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.DropDownWidth = Convert.ToInt32(hashtable["width"].ToString());
            comboBox.Location = (Point)hashtable["point"];
            comboBox.BackColor = (Color)hashtable["color"];
            comboBox.Name = hashtable["name"].ToString();
            comboBox.DisplayMember = "value";
            comboBox.ValueMember = "Key";
            return comboBox;
        }

        public ListView GetListView(Hashtable hashtable)
        {
            ListView listView = new ListView();
            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;
            listView.BackColor = (Color)hashtable["color"];
            listView.Name = hashtable["name"].ToString();
            listView.MouseClick += (MouseEventHandler)hashtable["click"];
            return listView;
        }
    }
}
