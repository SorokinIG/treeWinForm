using System;

using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            textBox2.Text = "Узел()";
            textBox3.Text = "некое_значение";


            var nodeMenu = new ContextMenuStrip();

            ToolStripMenuItem openLabel = new ToolStripMenuItem();
            openLabel.Text = "Добавить";

            ToolStripMenuItem deleteLabel = new ToolStripMenuItem();
            deleteLabel.Text = "Удалить";

            nodeMenu.Items.AddRange(new ToolStripMenuItem[] {openLabel, deleteLabel });

            treeView1.ContextMenuStrip = nodeMenu;

            treeView1.NodeMouseHover += focused;

            openLabel.Click += insert;
            deleteLabel.Click += delete;

            
        }

        void focused(object sender, TreeNodeMouseHoverEventArgs e) 
        {
            ToolTip tt = new ToolTip();

            if (e.Node.ToolTipText!=null)
            {

                
                    tt.Show(e.Node.Tag.ToString(), treeView1);
                
            }
       
            

            tt.AutoPopDelay = 2000;
        }
                 
        private  void insert(object sender, EventArgs e)
        {

            TreeNode node = new TreeNode(textBox2.Text);


            
            node.Tag = textBox3.Text;


            if (treeView1.SelectedNode == null)
            {
                treeView1.Nodes.Add(node);
            }
            else 
            {
                treeView1.SelectedNode.Nodes.Add(node);
            }
            treeView1.SelectedNode = null;
        }

        private void delete(object sender, EventArgs e)
        {
            

            TreeView tncoll = treeView1;

            if(tncoll.SelectedNode!=null)
            tncoll.SelectedNode.Remove();
            treeView1.CollapseAll();

            treeView1.SelectedNode = null;
        }

        private void search(TreeNodeCollection tncoll, string strNode, TreeView tv)
        {
          


                        foreach (TreeNode tnode in tncoll)
                        {

                            if (tnode.Tag.Equals(strNode))
                            {

                               tv.SelectedNode = tnode;
 

                               tv.SelectedNode.TreeView.Focus();
                            }

                        search(tnode.Nodes, strNode, tv);
                        }
           

        }

        private void edit()
        {
           

            
            treeView1.SelectedNode.Text = textBox2.Text;
            treeView1.SelectedNode.Tag = textBox3.Text;

            treeView1.SelectedNode = null;

        }

        private void button2_Click(object sender,EventArgs e)
        {

            if(treeView1.SelectedNode!=null)
            edit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            search(treeView1.Nodes,textBox1.Text, treeView1);
        }
    }
}
