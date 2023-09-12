using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace McqExaminationSystem.DataTransferObjectsManagers.UserExamRelationDtosManager
{
    public class UserExamRelationDTO
    {
        public long UserId { get; set; }

        public int ExamId { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime ExamDateAndTime { get; set; } = DateTime.UtcNow;

        public int ExamScore { get; set; }
    }
}
