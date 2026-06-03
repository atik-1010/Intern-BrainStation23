using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Dependency Injection Lifetimes
builder.Services.AddTransient<ITransientGuidService, TransientGuidService>();
builder.Services.AddScoped<IScopedGuidService, ScopedGuidService>();
builder.Services.AddSingleton<ISingletonGuidService, SingletonGuidService>();

var app = builder.Build();

app.MapControllers();

app.Run();


// Interfaces
public interface ITransientGuidService
{
    string GetGuid();
}

public interface IScopedGuidService
{
    string GetGuid();
}

public interface ISingletonGuidService
{
    string GetGuid();
}


// Implementations
public class TransientGuidService : ITransientGuidService
{
    private readonly Guid _id = Guid.NewGuid();

    public string GetGuid()
    {
        return _id.ToString();
    }
}

public class ScopedGuidService : IScopedGuidService
{
    private readonly Guid _id = Guid.NewGuid();

    public string GetGuid()
    {
        return _id.ToString();
    }
}

public class SingletonGuidService : ISingletonGuidService
{
    private readonly Guid _id = Guid.NewGuid();

    public string GetGuid()
    {
        return _id.ToString();
    }
}


// Controller
[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly ITransientGuidService _transient;
    private readonly IScopedGuidService _scoped;
    private readonly ISingletonGuidService _singleton;

    public HomeController(
        ITransientGuidService transient,
        IScopedGuidService scoped,
        ISingletonGuidService singleton)
    {
        _transient = transient;
        _scoped = scoped;
        _singleton = singleton;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var message =
            $"Transient : {_transient.GetGuid()}\n" +
            $"Scoped    : {_scoped.GetGuid()}\n" +
            $"Singleton : {_singleton.GetGuid()}";

        return Ok(message);
    }
}