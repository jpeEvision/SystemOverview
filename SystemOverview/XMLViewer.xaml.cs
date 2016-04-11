﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace SystemOverview
{
    /// <summary>
    /// Interaction logic for XMLViewer.xaml
    /// </summary>
    public partial class XMLViewer : UserControl
    {
        /// <summary>
        /// XML document
        /// </summary>
        private XmlDocument _xmldocument;
        public XMLViewer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// XML document to hold the xml string
        /// </summary>
        public XmlDocument xmlDocument
        {
            get { return _xmldocument; }
            set
            {
                _xmldocument = value;
                BindXMLDocument();
            }
        }
        /// <summary>
        /// Bind the XML document 
        /// </summary>
        private void BindXMLDocument()
        {
            if (_xmldocument == null)
            {
                xmlTree.ItemsSource = null;
                return;
            }

            XmlDataProvider provider = new XmlDataProvider();
            provider.Document = _xmldocument;
            Binding binding = new Binding();
            binding.Source = provider;
            binding.XPath = "child::node()";
            xmlTree.SetBinding(TreeView.ItemsSourceProperty, binding);
        }
    }
}
