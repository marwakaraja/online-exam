namespace McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager.ExamDtos
{
    public sealed record ExamDto(
        string ExamName,
        string ExamDescription,
        string PasswordExam,
        int ExamId = 0,
        bool IsDeleted = false);
}
