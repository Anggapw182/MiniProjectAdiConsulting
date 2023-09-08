namespace StudentAttendanceManagement.Services;

using AutoMapper;
using StudentAttendanceManagement.Entities;
using StudentAttendanceManagement.Models.Students;
using StudentAttendanceManagement.Repositories;


public interface IStudentsService
{
    Task<IEnumerable<StudentAttendanceModel>> GetAll();
    Task<StudentAttendanceModel> GetById(int id);
    Task Create(CreateRequestStudent model);
    Task Update(int id, UpdateRequestStudent model);
    Task Delete(int id);
}
public class StudentsService : IStudentsService
{
    private IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentsService(
        IStudentRepository StudentRepository,
        IMapper mapper)
    {
        _studentRepository = StudentRepository;
        _mapper = mapper;
    }

    public async Task Create(CreateRequestStudent model)
    {
        // map model to new user object
        var data = _mapper.Map<StudentAttendanceModel>(model);

        // save user
        await _studentRepository.Create(data);
    }

    public async Task Delete(int id)
    {
        await _studentRepository.Delete(id);
    }

    public async Task<IEnumerable<StudentAttendanceModel>> GetAll()
    {
        return await _studentRepository.GetAll();
    }

    public async Task<StudentAttendanceModel> GetById(int id)
    {
        var data = await _studentRepository.GetById(id);

        if (data == null)
            throw new KeyNotFoundException("Student not found");

        return data;
    }

    public async Task Update(int id, UpdateRequestStudent model)
    {
        var data = await _studentRepository.GetById(id);

        if (data == null)
            throw new KeyNotFoundException("Student not found");

        // copy model props to user
        _mapper.Map(model, data);
        _mapper.Map(model, data);

        // save user
        await _studentRepository.Update(data);
    }
}

