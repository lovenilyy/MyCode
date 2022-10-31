﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 高校宿舍管理系统
{
    public partial class FormXsAdd : Form
    {
        private SqlDataReader DR;

        public FormXsAdd()
        {
            InitializeComponent();
            InitialYq();
            InitialLz();
        }

        private void BT_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //stuLz
        public class stuLz
        {

            /// <summary>
            /// id
            /// </summary>		
            private int _id;
            public int id
            {
                get { return _id; }
                set { _id = value; }
            }
            /// <summary>
            /// Name
            /// </summary>		
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public stuLz(string name)
            {
                Name = name;
            }

        }
        //stuYq
        public class stuYq
        {

            /// <summary>
            /// id
            /// </summary>		
            private int _id;
            public int id
            {
                get { return _id; }
                set { _id = value; }
            }
            /// <summary>
            /// Name
            /// </summary>		
            private string _name;
            public string Name
            {
                get { return _name; }
                set { _name = value; }
            }
            public stuYq(string name)
            {
                Name = name;
            }
        }
        public void InitialYq()
        {
            string sql = "select * from stuYq ";
            DR = DbTool.lstl(sql);
            List<stuYq> lstYq = new List<stuYq>();
            lstYq.Add(new stuYq("-请选择-"));
            while (DR.Read())
            {
                string name = DR.GetString(1);
                stuYq item = new stuYq(name);
                lstYq.Add(item);
            }
            this.CB_Yq.DataSource = lstYq;
            this.CB_Yq.DisplayMember = "Name";
            this.CB_Yq.ValueMember = "Name";
        }
        public void InitialLz()
        {
            string sql = "select * from stuLz ";
            DR = DbTool.lstl(sql);
            List<stuLz> lstLz = new List<stuLz>();
            lstLz.Add(new stuLz("-请选择-"));
            while (DR.Read())
            {
                string name = DR.GetString(1);
                stuLz item = new stuLz(name);
                lstLz.Add(item);
            }
            this.CB_Lz.DataSource = lstLz;
            this.CB_Lz.DisplayMember = "Name";
            this.CB_Lz.ValueMember = "Name";
        }

        private void BT_Add_Click(object sender, EventArgs e)
        {
            string id = this.TB_id.Text.Trim();
            string name = this.TB_Name.Text.Trim();
            string xb = this.TB_Xb.Text.Trim();
            string yq = this.CB_Yq.Text.Trim();
            string lz = this.CB_Lz.Text.Trim();
            string fjh = this.CB_Fjh.Text.Trim();
            string ch = this.TB_Ch.Text.Trim();

            string sql = string.Format("insert into stuXx(id, Name, Xb, Yq, Lz, Fjh,Ch) values('" + id + "','" + name + "','" + xb + "','" + yq + "','" + lz + "','" + fjh + "','" + ch + "')");
            if (DbTool.Execute(sql))
            {
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
            FormXsgl fx = new FormXsgl();
            fx.Show();
            this.Hide();
        }
    }
}
