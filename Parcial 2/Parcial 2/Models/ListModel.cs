using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial_2.Models
{
	public class ListModel<T>
	{
		public List<T> Items { get; set; }

		public ListModel(List<T> list) {
			Items = list;
		}

		public ListModel() { }
	}
}