using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace AdmitOne
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitTimer(5);
        }

        private Timer timer = new Timer();
        private readonly Queue<AdmitInfo> patientQue = new Queue<AdmitInfo>();
        private void btnAdmit_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            if (string.IsNullOrEmpty(name)) return;

            var info = new AdmitInfo
            {
                Name = name,
                DateTime = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString()
            };
            patientQue.Enqueue(info);
        }

        private void InitTimer(int timerSec)
        {
            if (timer == null)
            {
                timer = new Timer();
            }

            timer.Interval = timerSec * 1000;
            timer.Elapsed += OnTimer;
            timer.AutoReset = true;
            timer.Start();
        }

        private void OnTimer(object sender, ElapsedEventArgs e)
        {
            if (patientQue.Count > 0)
            {
                var info = patientQue.Dequeue();
                var output = $"Next patient name: {info.Name} and admitted on {info.DateTime}";
                UpdateUi(output);
                return;
            }

            UpdateUi($"There is {patientQue.Count} patient is waiting.");
        }

        private void UpdateUi(string msg)
        {
            this.BeginInvoke((Action) delegate()
            {
                listBoxOut.Items.Add(msg);
                listBoxOut.SelectedIndex = listBoxOut.Items.Count - 1;
            });
        }
    }
}
