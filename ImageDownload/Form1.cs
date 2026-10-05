using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
//using static System.Net.WebRequestMethods;

namespace ImageDownload
{
    public partial class Form1 : Form
    {
        int cnt = 0;
        readonly string output_folder = "SavedImages";
        private readonly object lock_obj = new object();
        private int _num_threads = 1;
        private Stopwatch watch = new System.Diagnostics.Stopwatch();
        ConcurrentQueue<string> queue = null;

        public Form1()
        {
            InitializeComponent();
        }

        // Extract the file name from the image URL
        private string GetFileNameFromURL(string url)
        {
            Uri uri = new Uri(url);
            return System.IO.Path.GetFileName(uri.LocalPath);
        }

        private void DownloadQueue(object sender)
        {
            try
            {
                var bg = (sender as BackgroundWorker);
                while (!queue.IsEmpty)
                {
                    var b = queue.TryDequeue(out string url);  // Read the image URL
                    if (url == null || url.Trim().Length == 0) continue;
                    using (WebClient webClient = new WebClient())
                    {
                        webClient.Headers.Add("User-Agent", "MyCustomUserAgent");  // Set the request header
                        bg.ReportProgress(0, url);
                        webClient.DownloadFile(url, $"{output_folder}/{GetFileNameFromURL(url)}.jpg");

                    }
                }
            }
            catch
            {

            }
        }

        private void Bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lock (lock_obj)
            {
                cnt++;
                if (cnt == _num_threads)
                {
                    watch.Stop();
                    tmr_thread.Stop();
                    MessageBox.Show($"finished: {watch.ElapsedMilliseconds / 1000.0}");
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            DownloadQueue(sender);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            update_ui(0, (string)e.UserState);
        }


        private void tmr_single_thread_Tick(object sender, EventArgs e)
        {
            lbl_single_thread.Text = (int.Parse(lbl_single_thread.Text) + 1).ToString();
        }

        private void btn_multi_thread_Click(object sender, EventArgs e)
        {
            var lines = File.ReadAllLines("images.txt"); // Read image URLs from the file
            queue = new ConcurrentQueue<string>(lines); // Add image URLs to the queue

            // Configure the progress bar for download progress
            prg_thread.Minimum = 0;
            prg_thread.Value = 0;
            prg_thread.Maximum = lines.Length;
            lbl_single_thread.Text = "0";

            if (!Directory.Exists(output_folder))
            {
                Directory.CreateDirectory(output_folder);
            }
            cnt = 0;
            _num_threads = int.Parse(num_threads.Text);  // Read the number of threads from the input
            BackgroundWorker[] bgs = new BackgroundWorker[_num_threads]; // Create threads based on the number specified by the user
             
            // Define the task to be performed by each thread after it starts
            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i] = new BackgroundWorker();
                bgs[i].DoWork += backgroundWorker1_DoWork;
                bgs[i].WorkerReportsProgress = true;
                bgs[i].ProgressChanged += backgroundWorker1_ProgressChanged;
                bgs[i].RunWorkerCompleted += Bg_RunWorkerCompleted;

            }

            // Start the threads
            tmr_thread.Start();
            watch.Restart();
            for (int i = 0; i < bgs.Length; i++)
            {
                bgs[i].RunWorkerAsync();
            }
        }


        private void update_ui(int num_total, string url)
        {
            // Configure the progress bar to display download progress
            Invoke((MethodInvoker)delegate
            {
                prg_thread.Value++;
                lbl_dl_single.Text = $"Downloading file: {url}";
            });

        }
    }
}
