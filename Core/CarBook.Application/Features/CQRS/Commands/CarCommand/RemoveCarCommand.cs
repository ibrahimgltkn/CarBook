using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Commands.CarCommand
{
	public class RemoveCarCommand
	{
        public int Id { get; set; }

		public RemoveCarCommand(int id)
		{
			Id = id;
		}
	}
}
