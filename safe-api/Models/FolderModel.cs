using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace safe_api.Models;

public class FolderModel
{
    [Key]
    public int FolderId { get; set; }
    
    [Required, StringLength(36)]
    public string UserId { get; set; }
    
    public IdentityUser User { get; set; }
    
    public List<FileModel> Files { get; set; }
    
    public long TotalFiles { get; set; }
    
    public bool IsHidden { get; set; }
    
    [Required]
    public DateTime DateCreated { get; set; }
    
    [Required]
    public DateTime DateModified { get; set; }

    public FolderModel()
    {
        Files = new List<FileModel>();
        DateCreated =  DateTime.Now;
        DateModified =  DateTime.Now;
        IsHidden = false;
    }
}