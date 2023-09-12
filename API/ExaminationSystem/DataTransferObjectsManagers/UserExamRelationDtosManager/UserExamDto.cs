namespace McqExaminationSystem.DataTransferObjectsManagers.UserExamRelationDtosManager
{
    public record UserExamDto(
        string FullName,
        DateTime ExamDateTime,
        int ExamScore);
}
