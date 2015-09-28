using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.ComponentModel;

namespace Poker
{
    class Listener
    {
        HttpListener listener;
        BackgroundWorker worker;

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        Listener(string[] prefs)
        {
            listener = new HttpListener();
            foreach (string x in prefs)
            {
                listener.Prefixes.Add(x);
            }

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }

        Listener(string pref) : this(new string[] { pref }) { }

        public void Start()
        {
            worker.RunWorkerAsync();
        }
    }
}
