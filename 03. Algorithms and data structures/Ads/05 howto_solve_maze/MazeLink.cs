﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_howto_solve_maze
{
	class MazeLink
	{
		public MazeNode FromNode, ToNode;
		public MazeLink(MazeNode from_node, MazeNode to_node)
		{
			FromNode = from_node;
			ToNode = to_node;
		}
	}
}
