using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace DriveMapping
{
    public partial class DriveMapping : Form
    {
        public DriveMapping()
        {
            InitializeComponent();
        }

        private void ok()
        {
            string Brugermappe = textBox1.Text, Kodeord = " " + textBox2.Text, Server = textBox3.Text, Brugernavn = @" /user:" + textBox4.Text;

            if (textBox4.Text == "" && textBox2.Text != "")
            {
            }
            else if (textBox4.Text != "" && textBox2.Text != "")
            {
                Process tid = Process.Start("net.exe", @"use K: " + Server + Brugermappe + Brugernavn + Kodeord + " /persistent:no");
                tid.WaitForExit();
                if (tid.ExitCode != 0)
                {
                    MessageBox.Show("Kunne ikke oprette forbindelse!", "Fejl i oprettelse!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                }
                else
                {
                    MessageBox.Show("Forbindelse oprettet til: " + Server + Brugermappe);
                    button1.Visible = false;
                    button2.Visible = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    WindowState = FormWindowState.Minimized;
                }
            }
            else if (textBox4.Text != "" && textBox2.Text == "")
            {
                Process tid = Process.Start("net.exe", @"use K: " + Server + Brugermappe + Brugernavn + " /persistent:no");
                tid.WaitForExit();
                if (tid.ExitCode != 0)
                {
                    MessageBox.Show("Kunne ikke oprette forbindelse!", "Fejl i oprettelse!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                }
                else
                {
                    MessageBox.Show("Forbindelse oprettet til: " + Server + Brugermappe);
                    button1.Visible = false;
                    button2.Visible = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    WindowState = FormWindowState.Minimized;
                }
            }
            else if (textBox4.Text == "" && textBox2.Text == "")
            {
                Process tid = Process.Start("net.exe", @"use K: " + Server + Brugermappe + " /persistent:no");
                tid.WaitForExit();
                if (tid.ExitCode != 0)
                {
                    MessageBox.Show("Kunne ikke oprette forbindelse!", "Fejl i oprettelse!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BringToFront();
                }
                else
                {
                    MessageBox.Show("Forbindelse oprettet til: " + Server + Brugermappe);
                    button1.Visible = false;
                    button2.Visible = true;
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    textBox4.Enabled = false;
                    WindowState = FormWindowState.Minimized;
                }
            }
        }
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        private void DriveMapping_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.BalloonTipTitle = "DriveMapping";
                notifyIcon1.BalloonTipText = "Dobbeltklik for at åbne";
                notifyIcon1.ShowBalloonTip(3000);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string Bruger = textBox1.Text, Kodeord = textBox2.Text, Server = textBox3.Text;

            Process tid = Process.Start("net.exe", @"use K: /d");
            tid.WaitForExit();
            if (tid.ExitCode == 0)
            {
                MessageBox.Show("Forbindelse til: " + Server + Bruger + " Afbrudt!");
                Close();
            }
        }

        private void DriveMapping_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (textBox1.Enabled == false)
            {
                string Bruger = textBox1.Text, Kodeord = textBox2.Text, Server = textBox3.Text;

                Process tid = Process.Start("net.exe", @"use K: /d");
                tid.WaitForExit();
                if (tid.ExitCode == 0)
                {
                    MessageBox.Show("Forbindelse til: " + Server + Bruger + " Afbrudt!");
                    Close();
                }
            }
        }

        private void DriveMapping_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ok();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ok();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ok();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ok();
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ok();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                ok();
            }
        }
    }
}
