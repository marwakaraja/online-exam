using McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager.ExamDtos;
using McqExaminationSystem.Models;
using McqExaminationSystem.Repositories.ExamRepository;

namespace McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager
{
    public class ExamDtosManager : IExamDtosManager
    {
        private readonly IExamRepository examRepository;

        public ExamDtosManager(IExamRepository examRepository)
        {
            this.examRepository = examRepository;
        }

        public List<ExamDto> GetAllDtos()
        {
            var exams = examRepository.GetAll();
            var examsDtos = new List<ExamDto>();

            exams.ForEach(exam =>
            {
                examsDtos.Add(new ExamDto(
                    exam.ExamName,
                    exam.ExamDescription,
                    exam.PasswordExam,
                    exam.ExamId,
                    exam.IsDeleted));
            });

            return examsDtos;
        }

        public ExamDto? GetDtoById(int id)
        {
            var exam = examRepository.GetById(id);
            return exam == null ?
                   null
                   : new ExamDto(
                    exam.ExamName,
                    exam.ExamDescription,
                    exam.PasswordExam,
                    exam.ExamId,
                    exam.IsDeleted);
        }

        public bool InsertEntityUsingDto(ExamDto entity)
        {
            return examRepository.Insert(new Exam()
            {
               ExamName = entity.ExamName,
               ExamDescription = entity.ExamDescription,
               PasswordExam= entity.PasswordExam
            });
        }

        public bool UpdateEntityUsingDto(ExamDto entity)
        {
            return examRepository.Update(new Exam()
            {
                ExamId = entity.ExamId,
                ExamName = entity.ExamName,
                ExamDescription = entity.ExamDescription,
                PasswordExam= entity.PasswordExam
            });
        }

        public bool DeleteEntity(int id)
        {
            return examRepository.Delete(id);
        }
    }
}
