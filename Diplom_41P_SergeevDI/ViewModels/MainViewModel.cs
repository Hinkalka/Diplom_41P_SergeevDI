using GalaSoft.MvvmLight;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Diplom_41P_SergeevDI.viewmodels
{
    class MainViewModel : ViewModelBase
    {
        private string _IP;
        public string IP
        { get { return _IP; }
        set
            {
                _IP = value;
                
            }
        }
        private int _Port;
        public int Port
        {
            get { return _Port; }
            set
            {
                _Port = value;

            }
        }
        private string _Nick;
        public string Nick
        {
            get { return _Nick; }
            set
            {
                _Nick = value;

            }
        }
        private string _Chat;
        public string Chat
        {
            get { return _Chat; }
            set
            {
                _Chat = value;

            }
        }
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;

            }
        }
        TcpClient client;
        StreamReader sr;
        StreamWriter sw;
        

        public MainViewModel()
        {
            IP = "192.168.0.102";
            Port = 5050;
            Nick = "1";
            Task.Factory.StartNew(()=>
                {
                while (true)
                {
                    try
                    {
                        if(client?.Connected == true)
                        {
                            var line = sr.ReadLine();
                            if(line !=null)
                            {
                                Chat += line + "\n";
                            }
                            else
                            {
                                client.Close();
                                Chat += "ConnectedError" + "\n";
                            }
                        }
                        Task.Delay(10).Wait();
                    }
                    catch (Exception)
                    {

                    }
                }
            });
        }
        public AsyncCommand ConnectCommand
        {
            get
            {
                return new AsyncCommand(() =>
                {
                    return Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            client = new TcpClient();
                            client.Connect(IP, Port);
                            sr = new StreamReader(client.GetStream());
                            sw = new StreamWriter(client.GetStream());
                            sw.AutoFlush = true;
                            sw.WriteLine($"Login: {Nick}");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    });
                });
            }
        }
        public AsyncCommand SendCommand
        {
            get
            {
                return new AsyncCommand(() =>
                {
                    return Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            sw.WriteLine($"{Message}");
                            Message = "";
                        }
                        catch (Exception ex)
                        { }
                    });
                });
            }
        }
    }
}
