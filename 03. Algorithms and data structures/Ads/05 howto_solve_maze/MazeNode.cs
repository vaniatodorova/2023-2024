using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace _05_howto_solve_maze
{
	class MazeNode
	{
		public const int North = 0;
		public const int South = North + 1;
		public const int East = South + 1;
		public const int West = East + 1;

		public MazeNode[] AdjacentNodes = new MazeNode[4];

		public MazeNode Predecessor = null;

		public RectangleF Bounds;

		public bool InPath = false;

		public List<MazeNode> Neighbors = null;

		public PointF Center
		{
			get
			{
				float x = Bounds.Left + Bounds.Width / 2f;
				float y = Bounds.Top + Bounds.Height / 2f;
				return new PointF(x, y);
			}
		}

		public MazeNode(float x, float y, float wid, float hgt)
		{
			Bounds = new RectangleF(x, y, wid, hgt);
		}

		public void DrawBoundingBox(Graphics gr, Pen pen)
		{
			gr.DrawRectangle(pen,
				Bounds.Left + 1, Bounds.Y + 1,
				Bounds.Width - 2, Bounds.Height - 2);
		}

		public void DrawCenter(Graphics gr, Brush brush)
		{
			DrawCenter(gr, brush, 4);
		}

		public void DrawCenter(Graphics gr, Brush brush, float radius)
		{
			float cx = Bounds.Left + Bounds.Width / 2;
			float cy = Bounds.Top + Bounds.Height / 2;
			gr.FillEllipse(brush, cx - radius, cy - radius, 2 * radius, 2 * radius);
		}

		public void DrawPredecessorLink(Graphics gr, Pen pen)
		{
			if ((Predecessor != null) && (Predecessor != this))
				gr.DrawLine(pen, Center, Predecessor.Center);
		}

		public void DrawNeighborLinks(Graphics gr, Pen pen)
		{
			foreach(MazeNode neighbor in AdjacentNodes)
			{
				if(neighbor != null)
				{
					int dx = (int)(0.4 * (neighbor.Center.X - Center.X));
					int dy = (int)(0.4 * (neighbor.Center.Y - Center.Y));
					PointF pt = new PointF(Center.X + dx, Center.Y + dy);
					gr.DrawLine(pen, Center, pt);
				}
			}
		}

		public void DrawWalls(Graphics gr, Pen pen)
		{
			for(int side = 0; side < 4; side++)
			{
				if((AdjacentNodes[side] == null) ||
					((AdjacentNodes[side].Predecessor != this) &&
						(AdjacentNodes[side] != this.Predecessor)))
				{
					DrawWall(gr, pen, side, 0);
				}
			}
		}

		private void DrawWall(Graphics gr, Pen pen, int side, int offset)
		{
			switch (side)
			{
				case North:
					gr.DrawLine(pen,
						Bounds.Left + offset, Bounds.Top + offset,
						Bounds.Right - offset, Bounds.Top + offset);
					break;
				case South:
					gr.DrawLine(pen,
						Bounds.Left + offset, Bounds.Bottom - offset,
						Bounds.Right - offset, Bounds.Bottom - offset);
					break;
				case East:
					gr.DrawLine(pen,
						Bounds.Right - offset, Bounds.Top + offset,
						Bounds.Right - offset, Bounds.Bottom - offset);
					break;
				case West:
					gr.DrawLine(pen,
						Bounds.Left + offset, Bounds.Top + offset,
						Bounds.Left + offset, Bounds.Bottom - offset);
					break;
			}
		}

		public void DefineNeighbors()
		{
			Neighbors = new List<MazeNode>();
			foreach(MazeNode adj in AdjacentNodes)
			{
				if((adj != null)&&
					((adj.Predecessor == this) ||
					 (adj == this.Predecessor)))
				{
					Neighbors.Add(adj);
				}
			}
		}

	}
}
