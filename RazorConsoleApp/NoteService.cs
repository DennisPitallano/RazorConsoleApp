using System.Text.Json;

namespace RazorConsoleApp;

public class NoteService
{
    private readonly List<Note> _notes = new();
    private int _nextId = 1;
    private readonly string _dataFilePath = "notes.json";

    public NoteService()
    {
        LoadNotes();
    }

    private void LoadNotes()
    {
        if (!File.Exists(_dataFilePath))
        {
            return;
        }

        try
        {
            var json = File.ReadAllText(_dataFilePath);
            var data = JsonSerializer.Deserialize<NoteData>(json);
            if (data != null)
            {
                _notes.Clear();
                _notes.AddRange(data.Notes);
                _nextId = data.NextId;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading notes: {ex.Message}");
        }
    }

    private void SaveNotes()
    {
        try
        {
            var data = new NoteData
            {
                Notes = _notes,
                NextId = _nextId
            };
            var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_dataFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving notes: {ex.Message}");
        }
    }

    public List<Note> GetAllNotes() => _notes.OrderByDescending(n => n.UpdatedAt).ToList();

    public Note? GetNoteById(int id) => _notes.FirstOrDefault(n => n.Id == id);

    public void CreateNote(string title, string content)
    {
        var note = new Note
        {
            Id = _nextId++,
            Title = title,
            Content = content,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
        _notes.Add(note);
        SaveNotes();
    }

    public bool UpdateNote(int id, string title, string content)
    {
        var note = GetNoteById(id);
        if (note == null) return false;

        note.Title = title;
        note.Content = content;
        note.UpdatedAt = DateTime.Now;
        SaveNotes();
        return true;
    }

    public bool DeleteNote(int id)
    {
        var note = GetNoteById(id);
        if (note == null) return false;

        _notes.Remove(note);
        SaveNotes();
        return true;
    }
}

public class NoteData
{
    public List<Note> Notes { get; set; } = new();
    public int NextId { get; set; } = 1;
}
