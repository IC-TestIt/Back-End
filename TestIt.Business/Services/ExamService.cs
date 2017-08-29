﻿using System;
using System.Collections.Generic;
using System.Text;
using TestIt.Data.Abstract;
using TestIt.Model.Entities;

namespace TestIt.Business.Services
{
    public class ExamService : IExamService
    {
        private IExamRepository examRepository;
        
        public ExamService(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public void Save(Exam e)
        {
            examRepository.Add(e);
            examRepository.Commit();
        }
        public IEnumerable<Exam> GetStudentExams(int id)
        {
            var exams = examRepository.FindBy(x => x.StudentId == id);
            return exams;
        }
    }
}
