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
            //---------------------------------
            // テーブル初期化
            //---------------------------------
            initTable(materialTable);
            initTable(materialTable2);
            init = true;

            //---------------------------------
            // コンボボックス初期化
            //---------------------------------
            cb_cost.SelectedIndex = 0;
            cb_level.SelectedIndex = 0;
            cb_count.SelectedIndex = 0;
        }


        //---------------------------------
        // テーブルを初期化するメソッド
        //---------------------------------
        private void initTable(DataGridView dgv)
        {
            dgv.RowCount = 9;
            dgv.ColumnCount = 20;
            dgv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            //ランクはi、コストはj+3
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
                    else if (i < 8 && (CalcCost(i, j + 3, j + 3) <= MINCOST[i + 1] || (j > 1 && CalcCost(i, j + 3, j + 2) <= MINCOST[i + 1]))) 
                    {
                        dgv.Rows[i].Cells[j].Style.BackColor = Color.SkyBlue;
                    }
                    else
                        break;
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
        private int CalcCost(int rank, int a, int b)
        {
            if (rank != 0)
                return (a + b + rank + 1) / 2;
            else
                return (a + b + 2) / 2;
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


        //-----------------------------------------------------
        // リセットボタン押下時のイベントハンドラ
        //-----------------------------------------------------
        private void bt_reset_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    materialTable.Rows[i].Cells[j].Value = null;
                    materialTable2.Rows[i].Cells[j].Value = null;
                }
            }

            cb_cost.SelectedIndex = 0;
            cb_level.SelectedIndex = 0;
            cb_count.SelectedIndex = 0;
        }


        //-----------------------------------------------------
        // 計算ボタン押下時のイベントハンドラ
        //-----------------------------------------------------
        private void bt_calc_Click(object sender, EventArgs e)
        {

        }


        //-----------------------------------------------------
        // レベル変更時のイベントハンドラ
        // レベルに応じてコストコンボボックスの内容を変更する
        //-----------------------------------------------------
        private void cb_level_SelectedIndexChanged(object sender, EventArgs e)
        {
            //レベルは index + 1
            int level = ((ComboBox)sender).SelectedIndex + 1;   //レベルを取得
            cb_cost.Items.Clear();                              //コストコンボボックスのアイテムを全削除
            for(int i = MINCOST[level]; i <= MAXCOST; i++)
            {
                cb_cost.Items.Add(i.ToString());
            }
            cb_cost.SelectedIndex = 0;                          //最小コストを選択
        }
    }


}
