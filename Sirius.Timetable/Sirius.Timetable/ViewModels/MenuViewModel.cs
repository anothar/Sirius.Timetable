using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirius.Timetable.Helpers;
using Sirius.Timetable.Models;

namespace Sirius.Timetable.ViewModels
{
	public class MenuViewModel : ObservableObject
	{
		public MenuViewModel()
		{
			Items = new ObservableRangeCollection<Item>
			{
				new Item {Text = "Расписание"}
			};
		}
		public ObservableRangeCollection<Item> Items { get; set; }
	}
}