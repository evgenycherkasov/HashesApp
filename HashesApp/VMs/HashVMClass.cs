using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HashesApp.Interfaces;
using HashesApp.Models;
using HashesApp.Models.Helpers;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using HashesApp.ExceptionsClasses;
using HashesApp.Views.Custom_Elements;
using System.IO;

namespace HashesApp.VMs
{
    class HashVMClass : BindableBase
    {
        private string _text;
        private string _result;
        private IHash _hash;
        private bool _isStarted;
        private TextBoxView _textBox;

        public bool IsStarted
        {
            get
            {
                return _isStarted;
            }
            set
            {
                _isStarted = value;
                RaisePropertyChanged(nameof(IsStarted));
            }
        }
        public IHash Hash
        {
            private get
            {
                return _hash;
            }
            set
            {
                _hash = value;
            }
        }
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                RaisePropertyChanged(nameof(Text));
            }
        }

        public string Result
        {
            get
            {
                return _result;
            }
            set
            {
                _result = value;
                RaisePropertyChanged(nameof(Result));
            }
        }

        public DelegateCommand GetTextHash { get; }
        public DelegateCommand GetFileHash { get; }

        public HashVMClass()
        {
            GetTextHash = new DelegateCommand(() =>
            {
                try
                {
                    Validate();
                    IsStarted = true;
                    Thread thread = new Thread(() =>
                    {
                        Result = String.Empty;
                        byte[] inputText = Encoding.Default.GetBytes(Text);
                        string result = Hash.GetHash(inputText);
                        Result = result;
                        IsStarted = false;
                    });
                    thread.Start();
                }
                catch (ValidateException e)
                {
                    IsStarted = false;
                    _textBox = new TextBoxView(e.Message);
                    _textBox.ShowDialog();
                }
            });

            GetFileHash = new DelegateCommand(() =>
            {
                try
                {
                    Text = String.Empty;
                    OpenFileDialog ofd = new OpenFileDialog();
                    IsStarted = true;
                    if (ofd.ShowDialog() == true)
                    {
                        string path = ofd.FileName;
                        if (Hash.Name == "GOST")
                        {
                            Validate(isFileWork: true, path: path);
                        }
                        Thread thread = new Thread(() =>
                        {
                            string result = Hash.GetHash(path);
                            Result = result;
                            IsStarted = false;
                        });
                        thread.Start();
                    }
                }
                catch (ValidateException e)
                {
                    IsStarted = false;
                    _textBox = new TextBoxView(e.Message);
                    _textBox.ShowDialog();
                }
            });
        }

        private void Validate(bool isFileWork = false, string path = "")
        {
            if (String.IsNullOrEmpty(Text) && !isFileWork)
            {
                throw new ValidateException("Input text is empty!");
            }
            if (isFileWork)
            {
                if (path != String.Empty)
                {
                    long fileSize = FileWorkerClass.GetFileSizeByPath(path);
                    if (fileSize >= Math.Pow(2, 30) * 2)
                    {
                        throw new ValidateException("File is too large!");
                    }
                }
            }
        }

        public void ClearAll()
        {
            Result = String.Empty;
            Text = String.Empty;
        }

    }
}
