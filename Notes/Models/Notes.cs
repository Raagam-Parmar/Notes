using System;
using System.Threading.Tasks;

using Windows.Storage;

namespace Notes.Models;

public class Note
{
    private readonly StorageFolder _storageFolder = ApplicationData.Current.LocalFolder;
    public string Filename { get; set; } = String.Empty;
    public string Text { get; set; } = String.Empty;
    public DateTime Date { get; set; } = DateTime.Now;

    public Note()
    {
        Filename = "notes" + DateTime.Now.ToBinary().ToString() + ".txt";
    }

    public async Task SaveAsyc()
    {
        StorageFile noteFile = (StorageFile)await _storageFolder.TryGetItemAsync(Filename);

        if (noteFile is null)
        {
            noteFile = await _storageFolder.CreateFileAsync(Filename, CreationCollisionOption.ReplaceExisting);
        }

        await FileIO.WriteTextAsync(noteFile, Text);
    }

    public async Task DeleteAsync()
    {
        StorageFile noteFile = (StorageFile)await _storageFolder.TryGetItemAsync(Filename);

        if (noteFile is not null)
        {
            await noteFile.DeleteAsync();
        }
    }
}