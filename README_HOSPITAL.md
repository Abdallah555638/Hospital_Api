# Hospital_Api — Exam practice conversion

This is a rename-only practice copy of the provided `study_Api` source. Its architecture, CRUD logic, entity relationships and repository interfaces have been retained.

## Rename map

| Original | Hospital |
|---|---|
| Staff | Doctor |
| Guest | Patient |
| Department | Department |
| Room | Medical_Device |
| RoomName | DeviceName |
| StaffIds | DoctorIds |
| GuestId | PatientId |

Relations: Department (1) -> Doctors (many), Doctors <-> Patients (many to many), Patient (1) <-> Medical_Device (1).

## Open and run

1. Open `Hospital_Api.slnx` in Visual Studio; the application targets .NET 9.
2. Restore NuGet packages and ensure SQL Server is available. The `Defult` connection string key is retained because `Program.cs` reads that exact key.
3. The SQL Server instance name is copied from the original computer. Set the `Data Source` for **your** SQL Server instance in `Hospital_Api/appsettings.json`.
4. The database name is isolated as `HospitalStudyApi` so the original training database is not modified.
5. The provided migration `20261125064515_qwe` has had its entity and table names adapted; run `Update-Database` in Package Manager Console after selecting the `Hospital_Api` project, or use EF tooling if available.
6. Run the project and open Swagger. Its routes are `api/Department`, `api/Doctor`, and `api/Patient`.

## Existing issues noted in uploaded source (not changed here)

1. `PatientRepo.Add()` preserves an inverted condition from `GuestRepo.Add()`:

   ```csharp
   if (entity.medical_device == null)
   {
       await _db.Medical_Devices.AddAsync(entity.medical_device);
   }
   ```

   This may throw when the navigation is null. If you choose to fix the **original bug**, change `== null` to `!= null`. Alternatively rely on EF graph tracking when adding a Patient with an attached new Medical_Device, but verify lifecycle behavior.
2. The original PatientController has Add / GetAll / Update / Delete; no GetById endpoint was implemented. DoctorController has Add and GetById only; DepartmentController has Add only. The same missing CRUD endpoints remain missing deliberately.
3. The original Update Patient logic clears `Doctors` before validating all input IDs; if a later ID is missing, it returns NotFound after altering the tracked relationship collection. Keep this in mind when studying robust updates.
4. `DoctorIds` in AddPatientDto defaults to an empty list. In Update, omitting the property can therefore clear existing doctor links.
5. The sample `WeatherForecast` endpoint is retained unchanged apart from project namespace, because the request was to preserve code structure.

## Important

No `dotnet build`, SQL connection, or EF migration execution has been performed in this environment because the .NET SDK and your SQL Server instance are not available. The converted files have been checked statically for naming consistency. If Visual Studio reports an error, paste the compiler message so it can be checked against the exact source.
