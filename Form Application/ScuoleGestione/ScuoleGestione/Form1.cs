﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScuoleGestione
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;

            DataSet ds = new DataSet();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var cs = "Host=192.168.11.17; Username=postgres; Password=1234abcd; Database=gabba_DB";
            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT version()";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            var version = cmd.ExecuteScalar().ToString();

            labelTestConnessioneDB.Text = version;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVisualizzaRegistro_Click(object sender, EventArgs e)
        {
            var cs = "Host=192.168.11.17; Username=postgres; Password=1234abcd; Database=gabba_DB";
            var con = new NpgsqlConnection(cs);
            con.Open();

            var sql = "SELECT * FROM registro_voti_studenti";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            DataTable table = new DataTable();

            table.Load(reader);

            dataGridView1.DataSource = table;
            labelTestConnessioneDB.Text = table.TableName;
        }

        private void btnEliminazioneRiga_Click(object sender, EventArgs e)
        {
            var cs = "Host=192.168.11.17; Username=postgres; Password=1234abcd; Database=gabba_DB";
            var con = new NpgsqlConnection(cs);
            con.Open();

            var anno = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["anno"].Value;
            var sezione = dataGridView1.Rows[dataGridView1.SelectedCells[0].RowIndex].Cells["sezione"].Value;

            var sql = "DELETE FROM WHERE anno = " + anno + " AND sezione = '" + sezione + "'";

            NpgsqlCommand cmd = new NpgsqlCommand(sql, con);

            cmd.ExecuteNonQuery();
        }
    }
}
