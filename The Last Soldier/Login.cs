﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace The_Last_Soldier
{
    public partial class Login : Form
    {
        SqlConnection scon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\OBJECT ORIENTED PROGRAMMING 2\Project\DataBase\ArmyManInfo.mdf;Integrated Security=True;Connect Timeout=30");
        
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void loginbttn2_Click(object sender, EventArgs e)
        {
            panel1.BringToFront();
        }

        private void register_bttn_3_Click(object sender, EventArgs e)
        {
            panel2.BringToFront();
        }

        private void armyman_bttn_4_Click(object sender, EventArgs e)
        {
            panel3.BringToFront();
        }

        private void armymanf_bttn_5_Click(object sender, EventArgs e)
        {
            panel4.BringToFront();
        }

        private void admin_bttn_6_Click(object sender, EventArgs e)
        {
            panel5.BringToFront();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void armyloginbttn8_Click(object sender, EventArgs e)
        {
            scon.Open();
            string que = "select * from Armyman_info where Username ='" + textBox6.Text.Trim() + "' and PASS ='"+textBox7.Text.Trim()+ "' and Uni_id = '"+textBox8.Text.Trim()+"'";
            SqlCommand cmd = new SqlCommand(que, scon);
            SqlDataAdapter sda = new SqlDataAdapter(que, scon);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Armyman ar = new Armyman();
                this.Hide();
                ar.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username, Password or Unique id");
            }

            cmd.ExecuteNonQuery();
            scon.Close();
        }
    }
}