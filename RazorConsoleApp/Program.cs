// See https://aka.ms/new-console-template for more information

using RazorConsole.Core;
using RazorConsoleApp;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
services.AddSingleton<NoteService>();

await AppHost.RunAsync<NoteApp>(configure: builder =>
{
    builder.Services.AddSingleton<NoteService>();
});
