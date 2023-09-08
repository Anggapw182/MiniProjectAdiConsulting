using Dapper;
using StudentAttendanceManagement.Entities;
using StudentAttendanceManagement.Helpers;

namespace StudentAttendanceManagement.Repositories;

public interface IStudentRepository
{
    Task<IEnumerable<StudentAttendanceModel>> GetAll();
    Task<StudentAttendanceModel> GetById(int id);
    Task<StudentAttendanceModel> GetByName(string name);
    Task Create(StudentAttendanceModel data);
    Task Update(StudentAttendanceModel data);
    Task Delete(int id);
}

public class StudentsRepository : IStudentRepository
{
    private DataContext _context;

    public StudentsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task Create(StudentAttendanceModel data)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            INSERT INTO StudentsAttendence (StudentName, AttendencePercentage)
            VALUES (@StudentName, @AttendencePercentage)
        ";
        await connection.ExecuteAsync(sql, data);
    }

    public async Task Delete(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            DELETE FROM StudentsAttendence 
            WHERE Id = @id
        ";
        await connection.ExecuteAsync(sql, new { id });
    }

    public async Task<IEnumerable<StudentAttendanceModel>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAttendence
        ";
        return await connection.QueryAsync<StudentAttendanceModel>(sql);
    }

    public async Task<StudentAttendanceModel> GetById(int id)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAttendence 
            WHERE Id = @id
        ";
        return await connection.QuerySingleOrDefaultAsync<StudentAttendanceModel>(sql, new { id });
    }

    public async Task<StudentAttendanceModel> GetByName(string name)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            SELECT * FROM StudentsAttendence 
            WHERE StudentName = @name
        ";
        return await connection.QuerySingleOrDefaultAsync<StudentAttendanceModel>(sql, new { name });
    }

    public async Task Update(StudentAttendanceModel data)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
            UPDATE StudentsAttendence 
            SET StudentName = @StudentName,
                AttendencePercentage = @AttendencePercentage
            WHERE Id = @Id
        ";
        await connection.ExecuteAsync(sql, data);
    }
}

