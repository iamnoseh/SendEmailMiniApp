using Domain.Entities.EmailDomains;
using Infrastructure.Services.EmailService;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddScoped<ISendEmailService,SendEmailService>();
builder.Services.AddScoped<UserEmailOption>();

var config = builder.Configuration.GetSection("SMTPConfig");
builder.Services.Configure<SMTPConfigurationModel>(config);


// Learn more about configuring Swagger/OpenAPI at URL_ADDRESS
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "sendemailapi"));
}
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.MapControllers();
app.Run();


