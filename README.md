# RazorConsoleApp

A full-featured CRUD note-taking application built with **Blazor components** that runs entirely in the terminal! 🚀

## What's This?

This project demonstrates how to use Blazor's component model to build beautiful, interactive console applications. Instead of rendering to a browser, it renders directly to the terminal with colors, borders, and interactive UI elements.

## Features

- ✅ **Full CRUD Operations** - Create, Read, Update, Delete notes
- 🎨 **Beautiful Terminal UI** - Colored text, borders, and interactive buttons
- 🔄 **State Management** - Proper component lifecycle and data binding
- 💾 **JSON Persistence** - Notes are saved to `notes.json`
- 🎯 **Component-Based** - Clean, maintainable Razor component architecture

## Tech Stack

- **.NET 9.0**
- **Blazor Components** - For UI composition and state management
- **[Spectre.Console](https://spectreconsole.net/)** - For beautiful terminal rendering
- **[RazorConsole](https://github.com/YohDeadfall/RazorConsole)** - Bridge between Blazor and Spectre.Console

## Code Sample

```razor
<TextButton 
    Content="[+] Create" 
    OnClick="ShowCreateView" 
    BackgroundColor="@Spectre.Console.Color.Green" 
    FocusedColor="@Spectre.Console.Color.Lime" />
```

Yes, that's Razor syntax rendering to the console! 🤯

## Getting Started

### Prerequisites

- .NET 9.0 SDK or later

### Run

```bash
dotnet run --project RazorConsoleApp
```

## How It Works

The app uses Razor components with Blazor's component model:
- `@foreach` loops for rendering lists
- `@bind-Value` for two-way data binding
- Component lifecycle methods like `OnInitialized()`
- Event handlers with `OnClick`

But instead of HTML elements, it uses Spectre.Console components like `<Border>`, `<Markup>`, and `<TextButton>` that render to the terminal.

<img width="1632" height="749" alt="image" src="https://github.com/user-attachments/assets/57a08dcc-01de-4c5c-85a8-ff0f88ffa96e" />


## Credits

- **Spectre.Console** - Making terminal UIs beautiful since... well, recently!
- **RazorConsole** - For the brilliant idea of bringing Blazor to the console

## License

MIT - Do whatever you want with it!

---

*Built with ❤️ and a lot of curiosity about how far we can push Blazor*

