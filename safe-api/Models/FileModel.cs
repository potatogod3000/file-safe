using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace safe_api.Models;

public class FileModel
{
    [Key]
    public int FileId { get; set; }
    
    [Required, StringLength(36)]
    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }
    
    public List<FolderModel> Folders { get; set; }
    
    public long Size { get; set; }
    
    public bool IsHidden { get; set; }
    
    [Required]
    public DateTime DateUploaded { get; set; }
    
    [Required]
    public DateTime DateModified { get; set; }
    
    [Required, StringLength(1000)]
    public string Location { get; set; }

    public FileModel()
    {
        Folders = new List<FolderModel>();
        Location = string.Empty;
        DateUploaded = DateTime.Now;
        DateModified = DateTime.Now;
        IsHidden = false;
    }
}