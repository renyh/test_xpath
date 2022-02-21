//test 
using DigitalPlatform.Xml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace test_xpath
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xml = this.textBox_xml.Text.Trim();
            string xpath = this.textBox_xpath.Text.Trim();
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xml);

            XmlNode rootNode = dom.DocumentElement;
            string outerXml = DomUtil.GetElementOuterXml(rootNode, xpath);
            string innerXml = DomUtil.GetElementInnerXml(rootNode, xpath);
            string text = DomUtil.GetElementInnerText(rootNode, xpath);

            string info = "outerXml:" + outerXml + "\r\n"
                + "innerXml:" + innerXml + "\r\n"
                + "text:" + text;

            MessageBox.Show(this, info);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string xml = this.textBox_xml.Text.Trim();
            string xpath = this.textBox_xpath.Text.Trim();
            XmlDocument dom = new XmlDocument();
            dom.LoadXml(xml);

            XmlNode rootNode = dom.DocumentElement;

            XmlNodeList list = rootNode.SelectNodes(xpath);
            string info = "共找到["+list.Count+"]个节点"+"\r\n";
            foreach (XmlNode node in list)
            {
                info += node.InnerText + "\r\n";
            
            }

            MessageBox.Show(this, info);

        }
    }
}
