using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MeanMedianCalculator1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string[] unsortedArray = { "77", "78", "4", "50", "85", "61", "68", "10", "100", "3", "8", "22", "45", "82", "80",
            "1", "30", "32", "55", "7", "9", "20", "1000", "5", "29", "33", "76", "79", "62", "44"};

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                textBox1.Text += unsortedArray[i];
                textBox1.Text += Environment.NewLine;
            }

            string StartUpPath = Application.StartupPath;
            string filePath = StartUpPath + @"\unsorted_numbers.txt";

            // writes all numbers to a text file
            System.IO.File.WriteAllLines(@filePath, unsortedArray);
        }

        private int[] ConvertSortArray()
        {
            int[] unsortedArrayConv = new int[unsortedArray.Length];

            for (int i = 0; i < unsortedArray.Length; i++)
            {
                unsortedArrayConv[i] = Convert.ToInt32(unsortedArray[i]);
            }

            Array.Sort(unsortedArrayConv);

            return unsortedArrayConv;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false;
            button2.Enabled = true;
            int[] convertedArray = ConvertSortArray();
            int medianValue = convertedArray.Length % 2;

            for (int i = 0; i < convertedArray.Length; i++)
            {
                textBox2.Text += convertedArray[i].ToString();
                textBox2.Text += Environment.NewLine;
            }

            if (medianValue == 0)
            {
                medianValue = convertedArray.Length / 2;
                medianValue = convertedArray[medianValue];
                MessageBox.Show("The median of sorted values is: " + medianValue);
            }

           else
            {
                medianValue = convertedArray.Length / 2;
                int firstValue = convertedArray[medianValue];
                int secondValue = convertedArray[medianValue + 1];
                int newMedianValue = (firstValue + secondValue) / 2;
                MessageBox.Show("The median of sorted values is: " + newMedianValue);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] convertedArray = ConvertSortArray();
            int length = convertedArray.Length;
            int total = 0;
            for (int i = 0; i < convertedArray.Length; i++)
            {
                total += convertedArray[i];
            }
            int avg = total / length;
            MessageBox.Show("The median of sorted values is: " + avg);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }
    }
}
