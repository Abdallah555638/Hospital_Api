using Microsoft.EntityFrameworkCore;
using Hospital_Api.Data;
using Hospital_Api.Model;

namespace Hospital_Api.Repo
{
    public class PatientRepo : Genaric<Patient>
    {
        public PatientRepo(App_DbContext db) : base(db)
        {
        }

        public override async Task Add(Patient entity)
        {
            if(entity.medical_device == null)
            {
                await _db.Medical_Devices.AddAsync(entity.medical_device);
            }
            await _db.Patients.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public override async Task<IEnumerable<Patient>> GetAll()
        {
            return await _db.Patients.Include(x=>x.Doctors)
                .Include(x=>x.medical_device).ToListAsync();
        }

        public override async Task<Patient?> GetById(int id)
        {
            return await _db.Patients.Include(x=>x.Doctors)
                .Include(x=>x.medical_device).FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
