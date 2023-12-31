﻿using Mapster;
using SchoolManagement.Core.HelperServices;
using SchoolManagement.Services.Students.Entities;
using SchoolManagement.Services.Students.Exceptions;
using SchoolManagement.Services.Students.Helpers.PaginationEntities;
using SchoolManagement.Services.Students.Models.StudentModels;
using SchoolManagement.Services.Students.Producers;
using SchoolManagement.Services.Students.Repositories;

namespace SchoolManagement.Services.Students.Managers;

public class StudentManager : IStudentManager
{
    private const string StudentImageFolderName = "StudentImages";
    private readonly IUnitOfWork _unitOfWork;
    private readonly FileManager _fileManager;
    private readonly IStudentProducer _studentProducer;

    public StudentManager(IUnitOfWork unitOfWork, FileManager fileManager,IStudentProducer studentProducer)
    {
        _unitOfWork = unitOfWork;
        _fileManager = fileManager;
        _studentProducer = studentProducer;
    }

    public async ValueTask<IEnumerable<StudentModel>> GetStudentsAsync(StudentFilter studentFilter)
    {
        var students = await _unitOfWork.Students.GetAllWithFilterAsync(studentFilter);
        return students.Select(e => e.Adapt<StudentModel>());
    }

    public async ValueTask<StudentModel> GetByIdAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);
        return student is null ? throw new StudentNotFoundException() : student.Adapt<StudentModel>();
    }

   
    public async ValueTask UpdateAsync(Guid studentId, UpdateStudentModel model)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);

        if (student is null)
            throw new StudentNotFoundException();

        if (model.Photo is not null)
        {
            if (student.PhotoUrl is not null)
                _fileManager.DeleteFile(student.PhotoUrl);

            student.PhotoUrl = await _fileManager.SaveFileAsync(StudentImageFolderName, model.Photo);
        }

        student.FirstName = model.FirstName ?? student.FirstName;
        student.LastName = model.LastName ?? student.LastName;
        student.MiddleName = model.MiddleName ?? student.MiddleName;
        student.PhoneNumber = model.PhoneNumber ?? student.PhoneNumber;
        student.Username = model.Username ?? student.Username;

        await _unitOfWork.Students.UpdateAsync(student);
        await _studentProducer.PublishStudent(student);
    }

    public async ValueTask DeleteAsync(Guid studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);

        if (student is null)
            throw new StudentNotFoundException();

        if (student.PhotoUrl is not null)
            _fileManager.DeleteFile(student.PhotoUrl);

        await _unitOfWork.Students.DeleteAsync(student);
    }
}