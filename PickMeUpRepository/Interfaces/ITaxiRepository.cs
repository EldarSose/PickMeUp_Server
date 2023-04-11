﻿using PickMeUp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PickMeUp.Repository.Interfaces
{
	public interface ITaxiRepository : IGenericRepository<Taxi, int>
	{
		bool Delete(int id);
	}
}
