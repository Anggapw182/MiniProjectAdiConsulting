using Dapper;
using StudentAdmissionManagement.Entities;
using StudentAdmissionManagement.Helpers;
//using StudentAdmissionManagement.Model;

namespace StudentAdmissionManagement.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<StudentAdmissionDetailsModel>> GetAll();
    Task<StudentAdmissionDetailsModel> GetById(int id);
    Task<StudentAdmissionDetailsModel> GetByName(string name);
    Task Create(StudentAdmissionDetailsModel data);
    Task Update(StudentAdmissionDetailsModel data);
    Task Delete(int id);
}

public class StudentsRepository : IStudentRepository
{
    private DataContext _context;

    public StudentsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(StudentAdmissionDetailsModel data)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            INSERT INTO StudentsAdmission (StudentName, StudentClass, DateofJoining)
            VALUES (@StudentName, @StudentClass, @DateofJoining)
        ";
        await connection.ExecuteAsync(sql, data);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            DELETE FROM StudentsAdmission 
            WHERE Id = @id
        ";
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task<IEnumerable<StudentAdmissionDetailsModel>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAdmission
        ";
        return await connection.QueryAsync<StudentAdmissionDetailsModel>(sql);
    }

    public async Task<StudentAdmissionDetailsModel> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAdmission 
            WHERE Id = @id
        ";
        return await connection.QuerySingleOrDefaultAsync<StudentAdmissionDetailsModel>(sql, new { id });
    }

    public async Task<StudentAdmissionDetailsModel> GetByName(string name)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAdmission 
            WHERE StudentName = @name
        ";
        return await connection.QuerySingleOrDefaultAsync<StudentAdmissionDetailsModel>(sql, new { name });
    }

    public async Task Update(StudentAdmissionDetailsModel data)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            UPDATE StudentsAdmission 
            SET StudentName = @StudentName,
                StudentClass = @StudentClass,
                DateofJoining = @DateofJoining
            WHERE Id = @Id
        ";
        await connection.ExecuteAsync(sql, data);
    }
}

