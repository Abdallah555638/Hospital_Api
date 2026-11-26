using Microsoft.EntityFrameworkCore;
using Hospital_Api.Data;
using Hospital_Api.Model;

namespace Hospital_Api.Repo
{
    public class DoctorRepo : Genaric<Doctor>
    {
        public DoctorRepo(App_DbContext db) : base(db)
        {
        }

        public override async Task<IEnumerable<Doctor>> GetAll()
        {
            return await _db.Doctors.Include(x=>x.Department).ToListAsync();
        }

        public override async Task<Doctor?> GetById(int id)
        {
            return await _db.Doctors.Include(x=>x.Department).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
