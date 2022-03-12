using System;
using System.Drawing;
using System.Windows.Forms;

namespace NierCalculator
{
    public partial class Form1 : Form
    {
        readonly int[] MINCOST = { 4, 5, 6, 7, 9, 11, 14, 17, 21 };
        const int MAXCOST = 22;
        bool init = false;                                              //テーブルの初期化処理が終了しているかどうか


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initTable(materialTable);
            initTable(materialTable2);
            init = true;

            
        }


        //---------------------------------------------------------------------------------------------
        // テーブルを初期化するメソッド
        //---------------------------------------------------------------------------------------------
        private void initTable(DataGridView dgv)
        {
            dgv.RowCount = 9;
            dgv.ColumnCount = 20;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < 20; i++)
            {
                if (i > 0)
                    dgv.Columns[i].HeaderCell.Value = (i + 3).ToString();
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;    //ヘッダーセルを中央揃え
                dgv.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;                         //並び替えを不許可
                dgv.Columns[i].Width = 29;
            }
            for (int i = 0; i <= 8; i++)
            {
                dgv.Rows[i].Cells[0].Value = i.ToString();
                dgv.Rows[i].Cells[0].Value = i.ToString();
                dgv.Rows[i].Cells[0].ReadOnly = true;
                dgv.Rows[i].Height = 25;
            }
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    if (MINCOST[i] > j + 3)
                    {
                        dgv.Rows[i].Cells[j].ReadOnly = true;
                        dgv.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                    }
                }
            }

            dgv.Size = new Size(dgv.ColumnCount * 29 + 5, (dgv.RowCount + 1) * 25 + 5);
            dgv.ClearSelection();
        }


        //---------------------------------------------------------------------------------------------
        // コストを計算するメソッド
        // ランクnのコストaとコストbのチップを合成すると、コスト(a+b+n+1)/2(切り捨て)のチップができる。
        // ※ランク0はn=1
        //---------------------------------------------------------------------------------------------
        private int CalcCost(ushort rank, ushort a, ushort b)
        {
            if (rank != 0)
                return (int)((a + b + rank) / 2);
            else
                return (int)((a + b + 2) / 2);
        }


        //-----------------------------------------------------
        // ReadOnlyのセルを自動的にスキップするイベントハンドラ
        //-----------------------------------------------------
        private void materialTable_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (init)
            {
                DataGridView dgv = (DataGridView)sender;
                int rowIndex = e.RowIndex;
                int columnIndex = e.ColumnIndex;

                if (dgv.Rows[rowIndex].Cells[columnIndex].ReadOnly == false)
                    return; //選択したセルがReadOnlyでないなら処理しない
                else if (dgv.SelectedCells.Count >= 2)
                    return; //複数選択時は許可する
                else
                {
                    while (dgv.Rows[rowIndex].Cells[columnIndex].ReadOnly == true)
                    {
                        columnIndex++;
                    }
                    Action a = () => dgv.CurrentCell = dgv[columnIndex, rowIndex];
                    BeginInvoke(a);
                }
            }
        }


        //-----------------------------------------------------
        // セルを選択しても選択解除するイベントハンドラ
        //-----------------------------------------------------
        private void materialTable2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }


        //-----------------------------------------------------
        // 選択したセルをDelかBSで削除するイベントハンドラ
        //-----------------------------------------------------
        private void materialTable_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if((e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back))
            {
                foreach(DataGridViewCell c in dgv.SelectedCells)
                {
                    if (c.ReadOnly == false)
                        c.Value = null;
                }
            }
        }
    }


}
