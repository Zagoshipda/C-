using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace WinServer03
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TcpListener tcpListener = null;

        private void AcceptClient()
        {
            // continuously accept client connection.
            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                if (tcpClient.Connected)
                {
                    string str = ((IPEndPoint)tcpClient.Client.RemoteEndPoint).Address.ToString();
                    //listBox1.Items.Add(str);
                }

                EchoServer echoServer = new EchoServer(tcpClient);
                Thread th = new Thread(new ThreadStart(echoServer.Process));
                th.IsBackground = true;
                th.Start();

                //EchoServer echoServer = new EchoServer(tcpClient);
                //Thread th = new Thread(new ThreadStart(echoServer.Process));
                //th.IsBackground = true;
                //th.Start(tcpClient);


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(new ThreadStart(AcceptClient));
            th.IsBackground = true;
            th.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tcpListener = new TcpListener(IPAddress.Any, 3000);
            tcpListener.Start();
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            for(int i=0; i<host.AddressList.Length; ++i)
            {
                if(host.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    //textBox1.Text = host.AddressList[i].ToString();
                    break;
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tcpListener != null)
            {
                tcpListener.Stop();
                tcpListener = null;
            }
        }

    }


    // echo server는 BinaryReader, BinaryWriter 객체를 독립적으로 생성해주기 위해 일부러 따로 만들어준 클래스이다.
    // echo server의 instance 를 생성함으로써 독립적으로 읽고 쓸수 있는 객체들을 매번 만들어줄 수 있다.
    class EchoServer
    {
        TcpClient refClient;
        private BinaryReader br = null;
        private BinaryWriter bw = null;
        int intVal;
        float floatVal;
        string strVal;

        public EchoServer(TcpClient client)
        {
            refClient = client;
        }
        
        public void Process()
        {
            NetworkStream ns = refClient.GetStream();
            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                while (true)
                {
                    intVal = br.ReadInt32();
                    floatVal = br.ReadSingle();
                    strVal = br.ReadString();

                    bw.Write(intVal);
                    bw.Write(floatVal);
                    bw.Write(strVal);
                }
            }
            catch(SocketException se)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                refClient.Close();
                MessageBox.Show(se.Message);
                Thread.CurrentThread.Abort();
            }
            catch(IOException ie)
            {
                // when read & write is impossible.
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                refClient.Close();
                Thread.CurrentThread.Abort();
            }



        }

        public void Process(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream ns = client.GetStream();
            try
            {
                br = new BinaryReader(ns);
                bw = new BinaryWriter(ns);

                while (true)
                {
                    intVal = br.ReadInt32();
                    floatVal = br.ReadSingle();
                    strVal = br.ReadString();

                    bw.Write(intVal);
                    bw.Write(floatVal);
                    bw.Write(strVal);
                }
            }
            catch (SocketException se)
            {
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                refClient.Close();
                MessageBox.Show(se.Message);
                Thread.CurrentThread.Abort();
            }
            catch (IOException ie)
            {
                // when read & write is impossible.
                br.Close();
                bw.Close();
                ns.Close();
                ns = null;
                refClient.Close();
                Thread.CurrentThread.Abort();
            }



        }

    }

}
