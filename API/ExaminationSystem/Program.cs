using McqExaminationSystem.DataTransferObjectsManagers.ExamDtosManager;
using McqExaminationSystem.DataTransferObjectsManagers.UserDtosManager;
using McqExaminationSystem.Models;
using McqExaminationSystem.Repositories.ExamRepository;
using McqExaminationSystem.Repositories.QuestionRepository;
using McqExaminationSystem.Repositories.UserExamRelationRepository;
using McqExaminationSystem.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace McqExaminationSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<McqExaminationSystemDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultString")));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IUserDtosManager, UserDtosManager>();
            builder.Services.AddScoped<IExamRepository, ExamRepository>();
            builder.Services.AddScoped<IExamDtosManager, ExamDtosManager>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IUserExamRelationRepository, UserExamRelationRepository>();

            builder.Services.AddAuthentication(options =>
                options.DefaultAuthenticateScheme = "McqExaminationSystem")
                .AddJwtBearer("McqExaminationSystem", options =>
                {
                    string secretKey = "McqExaminationSystemProjectVersion1.0";
                    var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        IssuerSigningKey = encodedSecretKey,
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowClientAccess",
                    builder =>
                    {
                        builder.AllowAnyOrigin();
                        builder.AllowAnyMethod();
                        builder.AllowAnyHeader();
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowClientAccess");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}