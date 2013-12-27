using System;
using System.Collections.Generic;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace lmiforall_phone.templates
{
	public class JobCard
	{
		public class Skill
		{
			public string name { get; set; }
			public double score { get; set; }
			public int rank { get; set; }
		}

		public class Root
		{
			public string infotype { get; set; }
			public int soc { get; set; }
			public List<Skill> skills { get; set; }
		}
	}
}
