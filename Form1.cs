using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TSPJamaica
{
    public partial class Form1 : Form
    {
        private Dictionary<string, (double latitude, double longitude)> parishCoordinates;

        public Form1()
        {
            InitializeComponent();
            InitializeParishes();
            InitializeCoordinates();
        }

        private void InitializeParishes()
        {
            string[] parishes = { "Kingston", "St. Andrew", "St. Catherine", "Clarendon", "Manchester", "St. Elizabeth", "Westmoreland", "Hanover", "St. James", "Trelawny", "St. Ann", "St. Mary", "Portland", "St. Thomas" };
            StartVertexComboBox.Items.AddRange(parishes);
            EndVertexComboBox.Items.AddRange(parishes);
        }

        private void InitializeCoordinates()
        {
            parishCoordinates = new Dictionary<string, (double latitude, double longitude)>
            {
                { "Kingston", (17.9712, -76.7936) },
                { "St. Andrew", (18.0016, -76.7442) },
                { "St. Catherine", (17.9648, -76.8768) },
                { "Clarendon", (18.0308, -77.2167) },
                { "Manchester", (18.0426, -77.5071) },
                { "St. Elizabeth", (18.0055, -77.8541) },
                { "Westmoreland", (18.1923, -78.1334) },
                { "Hanover", (18.4057, -78.1334) },
                { "St. James", (18.4762, -77.8939) },
                { "Trelawny", (18.3268, -77.6595) },
                { "St. Ann", (18.4298, -77.1971) },
                { "St. Mary", (18.2312, -76.8782) },
                { "Portland", (18.1783, -76.4079) },
                { "St. Thomas", (17.9147, -76.4093) }
            };
        }

        private double CalculateHeuristic(string currentParish, string goalParish)
        {
            var current = parishCoordinates[currentParish];
            var goal = parishCoordinates[goalParish];

            // Calculation of the distance
            double distance = Math.Sqrt(Math.Pow(current.latitude - goal.latitude, 2) + Math.Pow(current.longitude - goal.longitude, 2));

            return distance;
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (StartVertexComboBox.SelectedIndex == -1 || EndVertexComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select both start and end vertices.");
                return;
            }

            string startParish = StartVertexComboBox.SelectedItem.ToString();
            string endParish = EndVertexComboBox.SelectedItem.ToString();

            int startVertex = StartVertexComboBox.SelectedIndex;
            int endVertex = EndVertexComboBox.SelectedIndex;

            
            int[,] graph = new int[,]
            {
                { 0, 8, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 20 },
                { 8, 0, 25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5 },
                { 25, 25, 0, 32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 32, 0, 38, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 38, 0, 27, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 27, 0, 30, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 30, 0, 26, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 26, 0, 18, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 18, 0, 22, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 22, 0, 20, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 20, 0, 19, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 19, 0, 25, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 25, 0, 22 },
                { 20, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 0 }
            };

            Graph g = new Graph();
            string path = "";
            int distance = 0;
            Stopwatch stopwatch = new Stopwatch();

            if (GreedySearchRadioButton.Checked)
            {
                stopwatch.Start();
                distance = g.Dijkstra(graph, startVertex, endVertex, out path);
                stopwatch.Stop();
                DisplayLabel.Text = $"Dijkstra's Algorithm selected\nFrom: {StartVertexComboBox.SelectedItem}\nTo: {EndVertexComboBox.SelectedItem}\nDistance: {distance}\nPath: {path}\nTime: {stopwatch.ElapsedMilliseconds} ms";
            }
            else if (AStarRadioButton.Checked)
            {
                stopwatch.Start();
                distance = g.AStar(graph, startVertex, endVertex, out path);
                stopwatch.Stop();
                DisplayLabel.Text = $"A* Search Algorithm selected\nFrom: {StartVertexComboBox.SelectedItem}\nTo: {EndVertexComboBox.SelectedItem}\nDistance: {distance}\nPath: {path}\nTime: {stopwatch.ElapsedMilliseconds} ms";
            }
            else if (BestFirstSearchRadioButton.Checked)
            {
                stopwatch.Start();
                distance = g.BestFirstSearch(graph, startVertex, endVertex, out path);
                stopwatch.Stop();
                DisplayLabel.Text = $"Best First Search Algorithm selected\nFrom: {StartVertexComboBox.SelectedItem}\nTo: {EndVertexComboBox.SelectedItem}\nDistance: {distance}\nPath: {path}\nTime: {stopwatch.ElapsedMilliseconds} ms";
            }
            else
            {
                MessageBox.Show("Please select a search method.");
            }
        }

        private void Form1_Load(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
