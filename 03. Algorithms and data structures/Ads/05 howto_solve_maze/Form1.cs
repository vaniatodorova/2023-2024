using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace _05_howto_solve_maze
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private int Xmin, Ymin, CellWid, CellHgt, NumRows, NumCols;
		private MazeNode[,] Nodes = null;
		private MazeNode StartNode = null, EndNode = null;

		private List<MazeNode> Path = null;


		private void btnCreate_Click(object sender, EventArgs e)
		{
			NumCols = int.Parse(txtWidth.Text);
			NumRows = int.Parse(txtHeight.Text);

			CellWid = picMaze.ClientSize.Width / (NumCols + 2);
			CellHgt = picMaze.ClientSize.Height / (NumCols + 2);
			if (CellWid > CellHgt) CellWid = CellHgt;
			else CellHgt = CellWid;
			Xmin = (picMaze.ClientSize.Width - NumCols * CellWid) / 2;
			Ymin = (picMaze.ClientSize.Height - NumRows * CellHgt) / 2;

			Nodes = MakeNodes(NumCols, NumRows);

			Path = null;
			StartNode = null;
			EndNode = null;

			FindSpanningTree(Nodes[0, 0]);

			DisplayMaze(Nodes);
		}

		private MazeNode[,] MakeNodes(int wid, int hgt)
		{
			MazeNode[,] nodes = new MazeNode[hgt, wid];
			for(int r=0; r < hgt; r++)
			{
				int y = Ymin + CellHgt * r;
				for(int c = 0; c < wid; c++)
				{
					int x = Xmin + CellWid * c;
					nodes[r, c] = new MazeNode(x, y, CellWid, CellHgt);
			    }
			}

			for (int r = 0; r < hgt; r++)
			{
				for(int c = 0; c < wid; c++)
				{
					if (r > 0)
						nodes[r, c].AdjacentNodes[MazeNode.North] = nodes[r - 1, c];
					if (r < hgt - 1)
						nodes[r, c].AdjacentNodes[MazeNode.South] = nodes[r + 1, c];
					if (c > 0)
						nodes[r, c].AdjacentNodes[MazeNode.West] = nodes[r, c - 1];
					if (c < wid - 1)
						nodes[r, c].AdjacentNodes[MazeNode.East] = nodes[r, c + 1];
				}
			}

			return nodes;
		}

		private void FindSpanningTree(MazeNode root)
		{
			Random rand = new Random();
			root.Predecessor = root;
			List<MazeLink> links = new List<MazeLink>();
			foreach(MazeNode neighbor in root.AdjacentNodes)
			{
				if (neighbor != null)
					links.Add(new MazeLink(root, neighbor));
			}

			while (links.Count > 0)
			{
				int link_num = rand.Next(0, links.Count);

				MazeLink link = links[link_num];
				links.RemoveAt(link_num);

				MazeNode to_node = link.ToNode;
				link.ToNode.Predecessor = link.FromNode;

				for(int i = links.Count - 1; i >= 0; i--)
				{
					if (links[i].ToNode.Predecessor != null)
						links.RemoveAt(i);
				}

				foreach(MazeNode neighbor in to_node.AdjacentNodes)
				{
					if ((neighbor != null) && (neighbor.Predecessor == null))
						links.Add(new MazeLink(to_node, neighbor));
				}
			}
		}

		private void DisplayMaze(MazeNode[,] nodes)
		{
			int hgt = nodes.GetUpperBound(0) + 1;
			int wid = nodes.GetUpperBound(1) + 1;
			Bitmap bm = new Bitmap(
				picMaze.ClientSize.Width,
				picMaze.ClientSize.Height);
			using(Graphics gr = Graphics.FromImage(bm))
			{
				gr.SmoothingMode = SmoothingMode.AntiAlias;
				for(int r = 0; r < hgt; r++)
				{
					for(int c = 0; c < wid; c++)
					{
						nodes[r, c].DrawWalls(gr, Pens.Black);
					}
				}
			}
			picMaze.Image = bm;
		}

		private void picMaze_MouseClick(object sender, MouseEventArgs e)
		{
			if (Nodes == null) return;
			if (e.Button == MouseButtons.Left)
				StartNode = FindNodeAt(e.Location);
			else if (e.Button == MouseButtons.Right)
				EndNode = FindNodeAt(e.Location);

			if ((StartNode != null) && (EndNode != null))
				StartSolving();

			picMaze.Refresh();
		}

		private MazeNode FindNodeAt(Point location)
		{
			if (location.X < Xmin) return null;
			if (location.Y < Ymin) return null;

			int row = (location.Y - Ymin) / CellHgt;
			if (row >= NumRows) return null;

			int col = (location.X - Xmin) / CellWid;
			if (col >= NumCols) return null;

			return Nodes[row, col];
		}

		private void picMaze_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			if (StartNode != null) StartNode.DrawCenter(e.Graphics, Brushes.Red);
			if (EndNode != null) EndNode.DrawCenter(e.Graphics, Brushes.Green);
			if((Path != null) && (Path.Count > 1))
			{
				List<PointF> points = new List<PointF>();
				foreach (MazeNode node in Path)
					points.Add(node.Center);
				e.Graphics.DrawLines(Pens.Red, points.ToArray());
			}
		}

		private void StartSolving()
		{
			Path = new List<MazeNode>();
			foreach (MazeNode node in Nodes)
				node.DefineNeighbors();

			Path.Add(StartNode);
			StartNode.InPath = true;

			Solve(EndNode, Path);

			foreach (MazeNode node in Path)
				node.InPath = false;

			picMaze.Refresh();
		}

		private bool Solve(MazeNode end_node, List<MazeNode> path)
		{
			MazeNode last_node = path[path.Count - 1];
			if (last_node == end_node) return true;

			foreach (MazeNode neighbor in last_node.Neighbors)
			{
				if (!neighbor.InPath)
				{
					path.Add(neighbor);
					neighbor.InPath = true;
					if (Solve(end_node, path)) return true;
					neighbor.InPath = false;
					path.RemoveAt(path.Count - 1);
				}
			}
			return false;
		}
	}
}
