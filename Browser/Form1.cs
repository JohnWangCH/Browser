using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Browser
{

    enum Page 
    {
        Page1,
        Page2,
        Page3,
        Page4
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            try
            {
                setPage(Page.Page1);
                webBrowser1.Navigate(new Uri("http://www.google.com"));
                webBrowser2.Navigate(new Uri("http://www.yahoo.com"));
                webBrowser3.Navigate(new Uri("http://www.google.com"));
                webBrowser4.Navigate(new Uri("http://www.youtube.com"));
                this.KeyPreview = true;
                this.KeyDown += new KeyEventHandler(Form_KeyDown);
                
            }
            catch (Exception e) 
            {

            }

            #region Auto scale layout setting

            int formHeight = Screen.PrimaryScreen.Bounds.Height;
            int formWidth = Screen.PrimaryScreen.Bounds.Width;

            this.Height = formHeight;
            this.Width = formWidth;

            double widthbase, heightbase;
            this.Tag = 452 + "|" + 795;
            widthbase = formWidth / double.Parse(this.Tag.ToString().Split('|')[1]);
            heightbase = formHeight / double.Parse(this.Tag.ToString().Split('|')[0]);

            foreach (Control o in this.Controls)
            {
                o.Tag = o.Top + "|" + o.Left + "|" + o.Height + "|" + o.Width;
                o.Width = (int)(double.Parse(o.Tag.ToString().Split('|')[3]) * widthbase);
                o.Height = (int)(double.Parse(o.Tag.ToString().Split('|')[2]) * heightbase);
                o.Left = (int)(double.Parse(o.Tag.ToString().Split('|')[1]) * widthbase);
                o.Top = (int)(double.Parse(o.Tag.ToString().Split('|')[0]) * heightbase);
            }

            webBrowser1.Location = new System.Drawing.Point(formWidth / 2 - 200, formHeight / 2);

            #endregion
        }

        private void setPage(Page page)
        {
            webBrowser1.Visible = false;
            webBrowser2.Visible = false;
            webBrowser3.Visible = false;
            webBrowser4.Visible = false;
            switch (page) 
            {
                case Page.Page1:
                    webBrowser1.Visible = true;
                    break;
                case Page.Page2:
                    webBrowser2.Visible = true;
                    break;
                case Page.Page3:
                    webBrowser3.Visible = true;
                    break;
                case Page.Page4:
                    webBrowser4.Visible = true;
                    break;
            }
        }

        void Form_KeyDown(object sender, KeyEventArgs e)
        {
           
            
            if (e.KeyCode == Keys.Escape) 
            {
                this.Close();
            }


            if (e.Control) 
            {
                switch(e.KeyCode){
                    case Keys.D1:
                        setPage(Page.Page1);
                        break;
                    case Keys.D2:
                        setPage(Page.Page2);
                        break;
                    case Keys.D3:
                        setPage(Page.Page3);
                        break;
                    case Keys.D4:
                        setPage(Page.Page4);
                        break;
                }
            }
        }

    }
}