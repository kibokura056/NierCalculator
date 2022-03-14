using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace NierCalculator
{
    public partial class Form1 : Form
    {
        readonly int[] MINCOST = { 4, 5, 6, 7, 9, 11, 14, 17, 21 };
        const int MAXCOST = 22;
        bool init = false;                                              //テーブルの初期化処理が終了しているかどうか
        int[,] partsCount = new int[9, 23];
        List<Log> log = new List<Log>();


        /// <summary>
        /// ログ記録のための構造体
        /// </summary>
        struct Log
        {
            public int rank;
            public int cost_a;
            public int cost_b;
            public int count;


            public Log(int rank, int cost_a, int cost_b)
            {
                this.rank = rank;
                this.cost_b = cost_b;
                this.cost_a = cost_a;
                this.count = 1;
            }
            public override string ToString()
            {
                return $"ランク+{rank}のコスト{cost_a} とコスト{cost_b} を合成 ⇒ ランク+{rank + 1}, コスト{CalcCost(rank, cost_a, cost_b)} ×{count}";
            }

            /// <summary>
            /// ランク・コストの組の大小を比較するために評価値に変換する
            /// </summary>
            /// <returns>評価値</returns>
            public int Assesment()
            {
                return Assesment(this.rank, this.cost_a, this.cost_b);
            }

            /// <summary>
            /// ランク・コストの組の大小を比較するために評価値に変換する
            /// </summary>
            /// <param name="rank">チップのランク</param>
            /// <param name="cost_a">チップのコストa</param>
            /// <param name="cost_b">チップのコストb</param>
            /// <returns>評価値</returns>
            public static int Assesment(int rank, int cost_a, int cost_b)
            {
                return int.Parse($"{rank}{cost_a:D2}{cost_b:D2}");
            }
        }


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
            cb_rank.SelectedIndex = 0;
            cb_count.SelectedIndex = 0;
        }


        /// <summary>
        /// テーブルを初期化する
        /// </summary>
        /// <param name="dgv">初期化したいmaterialTable</param>
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
                        dgv.Rows[i].Cells[j].Style.BackColor = Color.White;
                }
            }

            for (int i = 0; i <= 8; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    dgv.Rows[i].Cells[j].Value = null;
                }
            }

            dgv.Size = new Size(dgv.ColumnCount * 29 + 5, (dgv.RowCount + 1) * 25 + 5);
            dgv.ClearSelection();
        }


        /// <summary>
        /// チップ合成後のコストを計算するメソッド
        /// </summary>
        /// <param name="rank">合成するチップのランク</param>
        /// <param name="a">合成するチップのコストa</param>
        /// <param name="b">合成するチップのコストb</param>
        /// <returns>合成後のチップのコスト</returns>
        private static int CalcCost(int rank, int a, int b)
        {
            //---------------------------------------------------------------------------------------------
            // ランクnのコストaとコストbのチップを合成すると、コスト(a+b+n+1)/2(切り捨て)のチップができる。
            // ※ランク0はn=1
            //---------------------------------------------------------------------------------------------
            if (rank != 0)
                return (a + b + rank + 1) / 2;
            else
                return (a + b + 2) / 2;
        }



        /// <summary>
        /// ReadOnlyのセルを自動的にスキップするイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// セルを選択しても選択解除するイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialTable2_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            dgv.ClearSelection();
        }


        /// <summary>
        /// 選択したセルをDelかBSで削除するイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// リセットボタン押下時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_reset_Click(object sender, EventArgs e)
        {
            SwitchEnabled(false);

            initTable(materialTable);
            initTable(materialTable2);

            cb_cost.SelectedIndex = 0;
            cb_rank.SelectedIndex = 0;
            cb_count.SelectedIndex = 0;

            lb_NoEnoughParts.Visible = false;
            lb_log.Text = "合成ログがここに表示される。\n推奨: 記載される手順に従った合成。";

            SwitchEnabled(true);
        }



        /// <summary>
        /// 計算ボタン押下時のイベントハンドラ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bt_calc_Click(object sender, EventArgs e)
        {
            log.Clear();
            SwitchEnabled(false);
            initTable(materialTable2);

            //-----------------------------------------------------
            // 配列partsCountへの取り込み
            //-----------------------------------------------------
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    int val = 0;
                    //値が未入力でない かつ 整数値に変換できる場合は配列へ整数値を格納
                    if (materialTable.Rows[i].Cells[j].Value != null && int.TryParse(materialTable.Rows[i].Cells[j].Value.ToString(), out val)) 
                    {
                        if (val > 0)
                            partsCount[i, j + 3] = val;
                        else
                            partsCount[i, j + 3] = 0;
                    }
                    else
                    {
                        partsCount[i, j + 3] = 0;
                    }
                }
            }


            //-----------------------------------------------------
            // パーツ合成
            //-----------------------------------------------------
            int rank = cb_rank.SelectedIndex + 1;
            int cost = MINCOST[rank] + cb_cost.SelectedIndex;
            int count = cb_count.SelectedIndex + 1;

            bool result = Conv(rank, cost, count);


            //-----------------------------------------------------
            // materialTable2への出力
            //-----------------------------------------------------
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 1; j < 20; j++)
                {
                    if (materialTable.Rows[i].Cells[j].ReadOnly == false)
                        materialTable2.Rows[i].Cells[j].Value = partsCount[i, j + 3].ToString();
                }
            }
            materialTable2.Rows[rank].Cells[cost - 3].Style.BackColor = Color.Red;


            //-----------------------------------------------------
            // 合成ログへの出力
            //-----------------------------------------------------
            StringBuilder stb = new StringBuilder();
            if (result)
            {
                //合成できた場合は、パーツ不足の警告を非表示
                lb_NoEnoughParts.Visible = false;
            }
            else
            {
                //合成できなかった場合は、パーツ不足の警告を表示
                lb_NoEnoughParts.Visible = true;
                stb.Append("\n\n\n");
            }
            foreach (Log l in log)
            {
                stb.Append(l.ToString() + "\n");
            }
            lb_log.Text = stb.ToString();



            SwitchEnabled(true);
        }


        /// <summary>
        /// バックグランド処理中にユーザからの操作を受け付けないようにコントロールを無効にするメソッド
        /// </summary>
        /// <param name="b">有効にする場合true, 無効にする場合false</param>
        private void SwitchEnabled(bool b)
        {
            materialTable.Enabled = b;
            cb_rank.Enabled = b;
            cb_cost.Enabled = b;
            cb_count.Enabled = b;
            bt_calc.Enabled = b;
            bt_reset.Enabled = b;
        }


        /// <summary>
        /// 指定ランク,コスト,枚数を合成するメソッド
        /// </summary>
        /// <param name="rank">合成したいチップのランク</param>
        /// <param name="cost">合成したいチップのコスト</param>
        /// <param name="count">合成したいチップの枚数</param>
        /// <returns>合成できる場合true, できない場合false</returns>
        private bool Conv(int rank, int cost, int count)
        {
            //最小～最大コストの範囲外の場合はfalseを返す
            if (cost < MINCOST[rank] || cost > MAXCOST) return false;
            //既にパーツがある場合はそれを優先的に消費
            if (partsCount[rank, cost] >= count) return true;

            //-----------------------------
            // 合成フェーズ
            //-----------------------------
            //rank0の場合それ以上合成できないのでfalseを返す
            if (rank == 0) return false;

            for (int b = MAXCOST; b >= MINCOST[rank - 1]; b--)
            {
                for (int a = b; a >= MINCOST[rank - 1]; a--)
                {
                    int c = CalcCost(rank - 1, a, b);

                    if (c == cost)
                    {
                        do
                        {
                            //ロールバック用にバックアップを残しておく
                            //var log_bk = new List<Log>(log);
                            //int[,] partsCount_bk = new int[9, 23];
                            //Array.Copy(partsCount, partsCount_bk, partsCount.Length);


                            if (a == b && Conv(rank - 1, a, 2))
                            {
                                Conv(rank - 1, a, 2);
                                partsCount[rank - 1, a] -= 2;
                                partsCount[rank, cost]++;
                            }
                            else if (a != b && Conv(rank - 1, a, 1) && Conv(rank - 1, b, 1))
                            {
                                Conv(rank - 1, a, 1);
                                Conv(rank - 1, b, 1);
                                partsCount[rank - 1, a] -= 1;
                                partsCount[rank - 1, b] -= 1;
                                partsCount[rank, cost]++;
                            }
                            else
                            {
                                //ロールバックする
                                //log = new List<Log>(log_bk);
                                //Array.Copy(partsCount_bk, partsCount, partsCount.Length);

                                break;
                            }


                            //-----------------------------------
                            // 合成成功時、合成ログに記録する
                            //-----------------------------------
                            if (log.Count == 0) log.Add(new Log(rank - 1, a, b));   //ログが存在しない場合は追加
                            else
                            {
                                for (int i = 0; i < log.Count; i++)
                                {
                                    //既に同ランク、コストのチップが合成されていた場合は、その枚数を1増やすことで対応する
                                    if (log[i].rank == rank - 1 && log[i].cost_a == a && log[i].cost_b == b)
                                    {
                                        Log l = log[i];
                                        l.count++;
                                        log[i] = l;
                                        break;
                                    }
                                    //昇順で挿入されているため、現在のランク、コストより大きいエントリが存在した場合は、その時点のエントリの前に追加する
                                    else if (Log.Assesment(rank,a,b) < log[i].Assesment())
                                    {
                                        log.Insert(i, new Log(rank - 1, a, b));
                                        break;
                                    }
                                    //リストの末尾に到達した場合は、末尾に追加する
                                    else if(i == log.Count - 1)
                                    {
                                        log.Add(new Log(rank - 1, a, b));
                                        break;
                                    }
                                }
                            }


                            //合成後、数が足りた場合はその時点で終了
                            if (partsCount[rank, cost] >= count) return true;
                        } while (true);
                    }
                    else if (c < cost) break;
                }
            }
            //合成できるパーツの候補が全てダメだった場合はfalseを返して終了
            return false;
        }


        /// <summary>
        /// ランクコンボボックスの値変更時のイベントハンドラ
        /// </summary>
        /// <remarks>
        /// ランクに応じてコストコンボボックスの内容を変更する
        /// </remarks>
        private void cb_rank_SelectedIndexChanged(object sender, EventArgs e)
        {
            //レベルは index + 1
            int level = ((ComboBox)sender).SelectedIndex + 1;   //現在選択されているランクを取得
            cb_cost.Items.Clear();                              //コストコンボボックスのアイテムを全削除
            for(int i = MINCOST[level]; i <= MAXCOST; i++)      //当該ランクの最小コストからMAXCOSTまでの値をコストコンボボックスに追加していく
            {
                cb_cost.Items.Add(i.ToString());
            }
            cb_cost.SelectedIndex = 0;                          //最小コストを選択
        }
    }


}
