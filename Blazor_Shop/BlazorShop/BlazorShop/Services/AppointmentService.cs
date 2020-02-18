using BlazorShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorShop.Services
{
    public class AppointmentService
    {
        private readonly ApplicationDbContext _db;

        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public bool CreateAppoinment(Appointment appointment)
        {
            _db.Add(appointment);
            _db.SaveChanges();
            return true;
        }
    }
}
