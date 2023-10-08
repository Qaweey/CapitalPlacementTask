using AutoMapper;

using CapitalPlacementTask;
using CapitalPlacementTask.Dtos;
using CapitalPlacementTask.Extensions;
using CapitalPlacementTask.Models;
using CapitalPlacementTask.Repository.Interface;
using CapitalPlacementTask.Utilities;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");
var configuration = builder.Configuration;

builder.Services.AddCosmosDbService(configuration);
builder.Services.AddRepositoryService(configuration);
builder.Services.AddAutoMapper(typeof(MappingProfile));
var app = builder.Build();

//app.MapGet("/api/products", async (IServiceProvider services) =>
//{
//    //Write api logic

//    //var productService = services.GetRequiredService<ProductService>();
//    //var products = await productService.GetProductsAsync();
//    //await app.Response.WriteAsJsonAsync(products);
//});

// Programs Details EndPoints


app.MapPost("/api/ProgramsDetails", async ([FromBody] ProgramDetailsDto prog, IMapper mapper, [FromServices] IProgramDetails _programDetailsService) =>
{
    var response = new BaseResponse();

    var progData = mapper.Map<ProgramDetails>(prog);
    var addProgram = await _programDetailsService.CreateProgramDetails(progData);
    if (progData is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to add program";

        return Results.BadRequest(response);
    }
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = progData.CustId;
    response.Data = prog;
    return Results.Ok(response);

});

app.MapGet("/api/ProgramsDetails", async (string custId, IMapper mapper, [FromServices] IProgramDetails _programDetailsService) =>
{
    var response = new BaseResponse();
    var data = await _programDetailsService.GetProgramDetails(custId);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }
    var dtoData = mapper.Map<ProgramDetailsDto>(data);
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = custId;
    response.Data = dtoData;
    return Results.Ok(response);

});


app.MapPut("/api/ProgramsDetails", async (string custId, ProgramDetailsDto prog, IMapper mapper, [FromServices] IProgramDetails _programDetailsService) =>
{
    var response = new BaseResponse();
    var progData = mapper.Map<ProgramDetails>(prog);
    var data = await _programDetailsService.UpdateProgramDetailsAsync(custId, progData);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to update customer details";
        return Results.BadRequest(response);

    }
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = custId;
    response.Data = progData;
    return Results.Ok(response);

});





// Application Form EndPoints

app.MapPost("/api/Applicationform", async ([FromBody] ApplicationFormDto prog, IMapper mapper, [FromServices] IApplicationForm _appFormService) =>
{
    var response = new BaseResponse();
    var appFormData = mapper.Map<ApplicationForm>(prog);
    var addProgram = await _appFormService.CreateApplicationForm(appFormData);
    if (addProgram is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to add form";
        return Results.BadRequest(response);

    }
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = appFormData.CustId;
    response.Data = prog;
    return Results.Ok(response);


});


app.MapGet("/api/Applicationform", async (string custId, IMapper mapper, [FromServices] IApplicationForm _appFormService) =>
{
    var response = new BaseResponse();
    var data = await _appFormService.GetApplicationForm(custId);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);

    }
    var dtoData = mapper.Map<ApplicationFormDto>(data);
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = data.CustId;
    response.Data = dtoData;
    return Results.Ok(response);

});


app.MapPut("/api/Applicationform", async (string custId, ApplicationFormDto prog, IMapper mapper, [FromServices] IApplicationForm _appFormService) =>
{
    var response = new BaseResponse();
    var progData = mapper.Map<ApplicationForm>(prog);
    var data = await _appFormService.UpdateApplicationFormAsync(custId, progData);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }
    ;
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = data.CustId;
    response.Data = prog;
    return Results.Ok(response);

});


// WORKFLOW ENDPOINTS

app.MapPost("/api/WorkFlow", async ([FromBody] WorkFlowDto prog, IMapper mapper, [FromServices] IWorkFlow _workFlowService) =>
{
    var response = new BaseResponse();
    var workFlowData = mapper.Map<WorkFlow>(prog);
    var addWorkFlow = await _workFlowService.CreateWorkFlowDetails(workFlowData);
    if (addWorkFlow is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to add work flow data";
        return Results.BadRequest(response);
    }
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = addWorkFlow.CustId;
    response.Data = prog;
    return Results.Ok(response);


});


app.MapGet("/api/WorkFlow", async (string custId, IMapper mapper, [FromServices] IWorkFlow _workFlowService) =>
{
    var response = new BaseResponse();
    var data = await _workFlowService.GetWorkFlow(custId);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }
    var dtoData = mapper.Map<WorkFlowDto>(data);

    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = custId;
    response.Data = dtoData;
    return Results.Ok(response);

});


app.MapPut("/api/WorkFlow", async (string custId, WorkFlowDto prog, IMapper mapper, [FromServices] IWorkFlow _workFlowService) =>
{
    var response = new BaseResponse();
    var workFlowData = mapper.Map<WorkFlow>(prog);
    var data = await _workFlowService.UpdateProgramDetailsAsync(custId, workFlowData);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to update customer details";
        return Results.BadRequest(response);

    }
    ;
    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = custId;
    response.Data = prog;
    return Results.Ok(response);

});


//SUMMARY ENDPOINT

app.MapGet("/api/WorkFlow", async (string custId, IMapper mapper, [FromServices] IWorkFlow _workFlowService, [FromServices] IApplicationForm _appFormService, [FromServices] IProgramDetails _programDetailsService) =>
{
    var response = new BaseResponse();
    var data = await _workFlowService.GetWorkFlow(custId);
    if (data is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }
    var appData = await _appFormService.GetApplicationForm(custId);
    if (appData is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }
    var progData= await _programDetailsService.GetProgramDetails(custId);
    if (progData is null)
    {
        response.Code = Messages.FAILURE_CODE;
        response.Message = "Unable to find customer details";
        return Results.BadRequest(response);
    }

   

    var dtoData = mapper.Map<WorkFlowDto>(data);
    var dtoAppData = mapper.Map<ApplicationFormDto>(appData);
    var dtoProgData = mapper.Map<ProgramDetailsDto>(appData);
    var dto = new SummaryDataDto
    {
        WorkFlowInfo = dtoData,
        applicationFormInfo = dtoAppData,
        ProgramDetailsInfo = dtoProgData

    };

    response.Code = Messages.SUCCESS_CODE;
    response.Message = Messages.SUCCESS_MESSAGE;
    response.Id = custId;
    response.Data = dto;
    return Results.Ok(response);

});







//app.MapGet("/", () => "Hello World!");

app.Run();
