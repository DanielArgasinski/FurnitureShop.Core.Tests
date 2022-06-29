﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureShop.Core.DataInterface
{
    public interface IReservationRepository
    {
        IEnumerable<FurnitureReservation> AvailaleFurniture(DateTime date);
    }
}
