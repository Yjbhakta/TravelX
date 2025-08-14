var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.TravelX_Api>("travelx-api")
    .WithExternalHttpEndpoints();

var web = builder.AddProject<Projects.TravelX_Web>("travelx-web")
    .WithExternalHttpEndpoints()
    .WithReference(api);

builder.Build().Run();
