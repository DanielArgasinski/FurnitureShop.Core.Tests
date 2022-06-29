using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FurnitureShop.Core.Domain;

namespace FurnitureShop.Core.DataInterface
{
    public interface IFurnitureReservationRepository
    {
        void Save(FurnitureReservation furnitureReservation);
    }
}
